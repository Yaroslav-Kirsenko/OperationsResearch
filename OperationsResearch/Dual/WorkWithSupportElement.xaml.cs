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
    /// Логика взаимодействия для WorkWithSupportElement.xaml
    /// </summary>
    public partial class WorkWithSupportElement : Window
    {
        public WorkWithSupportElement()
        {
            InitializeComponent();
        }


        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            DeltaSearch deltaSearch = new DeltaSearch();

            deltaSearch.Show();

            this.Close();

        }

        private void Button_Click_Next(object sender, RoutedEventArgs e)
        {
            //SavedElements.ShowValues();
            //SavedElements.ShowValuesRezult();
            //SavedElements.ShowValuesZ();
            //SavedElements.ShowValuesSign();
            //SavedElements.ShowExtremum();
            //SavedElements.ShowadditionalVariables();
            //SavedElements.ShowFullArray();
            //SavedElements.ShowValuesDleta();

            WorkWithTablet workWithTablet = new WorkWithTablet();

            workWithTablet.CreateTextBox();

            workWithTablet.Show();

            this.Close();
        }

        private void Button_Click_The_End(object sender, RoutedEventArgs e)
        {

        }
    }
}
