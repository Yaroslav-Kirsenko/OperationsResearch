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
    /// Логика взаимодействия для ShowExample.xaml
    /// </summary>
    public partial class ShowExample : Window
    {
        public ShowExample()
        {
            InitializeComponent();
        }


        public void UpdateLabelContent(string content)
        {
            // Предположим, что Label с именем "displayLabel"
            displayLabel.Content = content;
        }

        
    }
}
