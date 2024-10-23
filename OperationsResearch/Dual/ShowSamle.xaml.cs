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

namespace OperationsResearch.Dual
{
    /// <summary>
    /// Логика взаимодействия для ShowSamle.xaml
    /// </summary>
    public partial class ShowSamle : Window
    {
        public ShowSamle()
        {
            InitializeComponent();
        }

        private void Button_Click_exit(object sender, RoutedEventArgs e)
        {
            ShowExample showExample = new ShowExample();
            showExample.Show();
            this.Close();
            
        }
        private void Button_Click_next(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
