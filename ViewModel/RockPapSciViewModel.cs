using laba5_wpff.Model;
using laba5_wpff.ViewModel.Helpers;
using System;
using System.ComponentModel;
using System.Windows.Input;

internal class RockPapSciViewModel : BindingHelper, INotifyPropertyChanged
{
    private RPCmodel _model;
    public event PropertyChangedEventHandler PropertyChanged;

    public RockPapSciViewModel()
    {
        _model = new RPCmodel();
        RockCommand = new DelegateCommand(RockAction);
        PaperCommand = new DelegateCommand(PaperAction);
        ScissorsCommand = new DelegateCommand(ScissorsAction);
        PlayCommand = new DelegateCommand(PlayGame, CanPlay);

        IsGamePlayable = false;
    }

    public ICommand RockCommand { get; private set; }
    public ICommand PaperCommand { get; private set; }
    public ICommand ScissorsCommand { get; private set; }
    public ICommand PlayCommand { get; private set; }

    private RPCmodel.Choice _playerChoice;
    public RPCmodel.Choice PlayerChoice
    {
        get => _playerChoice;
        set
        {
            _playerChoice = value;
            NotifyPropertyChanged("PlayerChoice");
            IsGamePlayable = true;
            NotifyPropertyChanged("IsGamePlayable");
        }
    }

    private RPCmodel.Choice _userSelection;
    public RPCmodel.Choice UserSelection
    {
        get => _userSelection;
        set
        {
            _userSelection = value;
            NotifyPropertyChanged("UserSelection");
        }
    }

    public RPCmodel.Choice ComputerChoice => _model.ComputerChoice;

    private string _winner;
    public string Winner
    {
        get => _winner;
        set
        {
            _winner = value;
            NotifyPropertyChanged("Winner");
        }
    }

    private bool _isGamePlayable;
    public bool IsGamePlayable
    {
        get => _isGamePlayable;
        set
        {
            _isGamePlayable = value;
            NotifyPropertyChanged("IsGamePlayable");
        }
    }

    public void GenerateComputerChoice()
    {
        Random random = new Random();
        _model.ComputerChoice = (RPCmodel.Choice)random.Next(0, 3);
        NotifyPropertyChanged("ComputerChoice");
    }

    private void RockAction()
    {
        PlayerChoice = RPCmodel.Choice.Rock;
        UserSelection = RPCmodel.Choice.Rock;
        PlayGame();
    }

    private void PaperAction()
    {
        PlayerChoice = RPCmodel.Choice.Paper;
        UserSelection = RPCmodel.Choice.Paper;
        PlayGame();
    }

    private void ScissorsAction()
    {
        PlayerChoice = RPCmodel.Choice.Scissors;
        UserSelection = RPCmodel.Choice.Scissors;
        PlayGame();
    }

    private void PlayGame()
    {
        GenerateComputerChoice();
        CheckWinner();
    }

    private void CheckWinner()
    {
        if (PlayerChoice == ComputerChoice)
        {
            Winner = "Ничья! (победила дружба)";
        }
        else if ((PlayerChoice == RPCmodel.Choice.Rock && ComputerChoice == RPCmodel.Choice.Scissors) ||
                 (PlayerChoice == RPCmodel.Choice.Scissors && ComputerChoice == RPCmodel.Choice.Paper) ||
                 (PlayerChoice == RPCmodel.Choice.Paper && ComputerChoice == RPCmodel.Choice.Rock))
        {
            Winner = "Юзер (да, ты крут, голос\nвсех поколений)";
        }
        else
        {
            Winner = "Компуктер (и восстали машины\nиз пепла..)";
        }
    }

    private void NotifyPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private bool CanPlay()
    {
        return IsGamePlayable;
    }
}