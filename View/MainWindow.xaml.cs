using laba5_wpff.View;
using laba5_wpff.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace laba5_wpff
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        //переход на окно с кликером
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Clicker clicker = new Clicker();
            clicker.ShowDialog();
            
        }

        //переход на окно с угадай-число
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GuessNumber guess = new GuessNumber();
            DataContext = new GuessNumberViewModel();
            guess.ShowDialog();
        }

        //переход на игру камень-ножницы-бумага
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            RockPapSciView rockPapSci = new RockPapSciView();
            DataContext = new RockPapSciViewModel();
            rockPapSci.ShowDialog();
        }


        //выход из проги
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
