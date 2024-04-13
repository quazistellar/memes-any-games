using System;
using System.ComponentModel;
using System.Windows.Input;
using laba5_wpff.Model;
using laba5_wpff.ViewModel.Helpers;

namespace laba5_wpff.ViewModel
{
    internal class GuessNumberViewModel : INotifyPropertyChanged
    {
        private GTNmodel _model;
        public event PropertyChangedEventHandler PropertyChanged;

        private void NewGame()
        {
            _model = new GTNmodel();
            CurrentGuess = 0;
            Feedback = string.Empty;
            TooLowMessage = string.Empty;
            TooHighMessage = string.Empty;
            NotifyPropertyChanged("CurrentGuess");
            NotifyPropertyChanged("Feedback");
            NotifyPropertyChanged("TooLowMessage");
            NotifyPropertyChanged("TooHighMessage");
            NotifyPropertyChanged("Attempts");
            ((DelegateCommand)CheckCommand).RaiseCanExecuteChanged();
           
        }

        public ICommand CheckCommand { get; set; }
        public ICommand NewGameCommand { get; }

   

        public GuessNumberViewModel()
        {
            _model = new GTNmodel();
            CheckCommand = new DelegateCommand(CheckGuess);
            NewGameCommand = new DelegateCommand(NewGame);
        }

        public int NumberToGuess => _model.NumberToGuess;

        private int _currentGuess;
        public int CurrentGuess
        {
            get => _currentGuess;
            set
            {
                _currentGuess = value;
                NotifyPropertyChanged("CurrentGuess");
                TooLowMessage = string.Empty;
                TooHighMessage = string.Empty;
                Feedback = string.Empty;
                NotifyPropertyChanged("TooLowMessage");
                NotifyPropertyChanged("TooHighMessage");
                NotifyPropertyChanged("Feedback");
                NotifyPropertyChanged("Attempts");
            }
        }

        public int Attempts => _model.Attempts;

        private string _feedback;
        public string Feedback
        {
            get => _feedback;
            set
            {
                _feedback = value;
                NotifyPropertyChanged("Feedback");
            }
        }

        private string _tooLowMessage;
        public string TooLowMessage
        {
            get => _tooLowMessage;
            set
            {
                _tooLowMessage = value;
                NotifyPropertyChanged("TooLowMessage");
            }
        }

        private string _tooHighMessage;
        public string TooHighMessage
        {
            get => _tooHighMessage;
            set
            {
                _tooHighMessage = value;
                NotifyPropertyChanged("TooHighMessage");
            }
        }

        private void CheckGuess()
        {
            _model.MakeGuess(_currentGuess);

            if (_currentGuess < _model.NumberToGuess)
            {
                TooLowMessage = "Введите большее число!";
                TooHighMessage = string.Empty;
            }
            else if (_currentGuess > _model.NumberToGuess)
            {
                TooHighMessage = "Введите меньшее число!";
                TooLowMessage = string.Empty;
            }
            else
            {
                Feedback = $"Балдеж! Вы угадали, это было число {_model.NumberToGuess}!";
                TooLowMessage = string.Empty;
                TooHighMessage = string.Empty;
            }

            NotifyPropertyChanged("TooLowMessage");
            NotifyPropertyChanged("TooHighMessage");
            NotifyPropertyChanged("Feedback");
            NotifyPropertyChanged("Attempts");
            ((DelegateCommand)CheckCommand).RaiseCanExecuteChanged();
        }

        //private bool CanCheckGuess()
        //{
        //    return CurrentGuess >= 1 && CurrentGuess <= 100;
        //}


        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}