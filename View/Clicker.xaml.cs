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
using System.Windows.Shapes;

namespace laba5_wpff.View
{
    /// <summary>
    /// Логика взаимодействия для Clicker.xaml
    /// </summary>
    public partial class Clicker : Window
    {
        public Clicker()
        {
            InitializeComponent();

            ClickerViewModel viewModel = new ClickerViewModel();
            this.DataContext = viewModel;


            MinHeight = 340;
            MinWidth = 310;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = GetWindow(this);

            if (window != null)
            {
                window.Close();
            }
        }
    }
}
