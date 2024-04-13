using laba5_wpff.Model;
using laba5_wpff.ViewModel.Helpers;
using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Threading.Tasks;

namespace laba5_wpff.ViewModel
{
    internal class ClickerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private CLKRmodel _model;
        private ICommand _clickCommand;
        private bool _isTimerRunning = false;

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

        private int _seconds;
        public int Seconds
        {
            get { return _seconds; }
            set
            {
                _seconds = value;
                NotifyPropertyChanged(nameof(Seconds));
                NotifyPropertyChanged(nameof(ClickCommandEnabled));
            }
        }

        public int ClicksPerMinute { get; private set; }

        public bool ClickCommandEnabled => Seconds > 0;

        public ClickerViewModel()
        {
            _model = new CLKRmodel();
            _clickCommand = new DelegateCommand(async () => await Click(), () => ClickCommandEnabled);
            Seconds = 60; 
        }

        public ICommand ClickCommand => _clickCommand;

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

                    _isTimerRunning = false;
                    CalculateClicksPerMinute();
                    NotifyPropertyChanged(nameof(ClickCommandEnabled));
                    SaveResult();
                });
            }

            Clicks++;
        }

        private void CalculateClicksPerMinute()
        {
            ClicksPerMinute = Seconds > 0 ? Clicks * 60 / (60 - Seconds) : 0;
            NotifyPropertyChanged(nameof(ClicksPerMinute));
        }

        private void SaveResult()
        {
            string result = $"Результат: {Clicks} - Кликов в минуту: {ClicksPerMinute}"; JsonHelper.Serialize(result);
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}