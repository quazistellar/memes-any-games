using laba5_wpff.Model;
using laba5_wpff.ViewModel.Helpers;
using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace laba5_wpff.ViewModel
{
    internal class ClickerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private CLKRmodel _model;
        private ICommand _clickCommand;
        private bool _isTimerRunning = false;
        private bool _firstRun = true;

        public int Clicks
        {
            get { return _model.Clicks; }

            set
            {
                _model.Clicks = value;
                CalculateClicksPerMinute();
                NotifyPropertyChanged(nameof(Clicks));
                NotifyPropertyChanged(nameof(ClicksPerMinute));
            }
        }

        private void Clear()
        {
            _model.Clicks = 0;
            Seconds = 60;
            NotifyPropertyChanged(nameof(Clicks));
            NotifyPropertyChanged(nameof(ClicksPerMinute));
            NotifyPropertyChanged(nameof(Seconds));
            NotifyPropertyChanged(nameof(ClickCommandEnabled));
            NotifyPropertyChanged(nameof(ClearCommand));
        }


        private int _seconds;
        public int Seconds
        {
            get { return _seconds; }
            set
            {
                _seconds = value;

                NotifyPropertyChanged(nameof(Seconds));
                NotifyPropertyChanged(nameof(ClickCommandEnabled));


                ClearCommand = new DelegateCommand(Clear);
            }
        }

        public int ClicksPerMinute { get; private set; }

        public bool ClickCommandEnabled => Seconds > 0;

        public ClickerViewModel()
        {
            _model = new CLKRmodel();
            try
            {
                _clickCommand = new DelegateCommand(async () => await Click(), () => ClickCommandEnabled);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Нажмите на кнопку один раз для запуска, на второй идут клики!");
            }
            Seconds = 60;
        }

        public ICommand ClickCommand => _clickCommand;

        public DelegateCommand ClearCommand { get; private set; }

        private async Task Click()
        {
            if (!_isTimerRunning)
            {
                _isTimerRunning = true;

                await Task.Run(async () =>
                {
                    while (Seconds > 0)
                    {
                        await Task.Delay(1000);
                        Seconds--;
                    }

                    CalculateClicksPerMinute();
                    _isTimerRunning = false;


                    NotifyPropertyChanged(nameof(ClickCommandEnabled));

                    try
                    {
                        SaveResult();

                    }
                    catch (Exception)
                    {

                    }
                });
            }

            if (_firstRun)
            {
                _firstRun = false;
            }
            else
            {
                Clicks++;
            }
        }

        private void CalculateClicksPerMinute()
        {
            try
            {
                ClicksPerMinute = Seconds > 0 ? Clicks * 60 / (60 - Seconds) : 0;
                NotifyPropertyChanged(nameof(ClicksPerMinute));
            }
            catch

            {
                MessageBox.Show("Нажмите на кнопку один раз для запуска, на второй идут клики!");
            }
        }

        private void SaveResult()
        {
            string result = $"Результат кликов за минуту: {Clicks}";


            JsonHelper.Serialize(result);

        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}