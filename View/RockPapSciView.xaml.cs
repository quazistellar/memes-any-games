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
    /// Логика взаимодействия для RockPapSciView.xaml
    /// </summary>
    public partial class RockPapSciView : Window
    {
        public RockPapSciView()
        {
            InitializeComponent();

            MinHeight = 320;
            MinWidth = 280;

            RockPapSciViewModel viewModel = new RockPapSciViewModel();
            this.DataContext = viewModel;
        }
    }
}
