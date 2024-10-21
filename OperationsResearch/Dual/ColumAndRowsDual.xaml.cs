
using System.Windows;
using System.Windows.Controls;

namespace OperationsResearch.Dual
{
    /// <summary>
    /// Логика взаимодействия для ColumAndRowsDual.xaml
    /// </summary>
    public partial class ColumAndRowsDual : Window
    {
        public ColumAndRowsDual()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string textFromTextBox1 = textBox1.Text;
            string textFromTextBox2 = textBox2.Text;
            int value;

            // Проверка на строка
            if (string.IsNullOrEmpty(textFromTextBox1))
            {
                errorMessage.Content = "Поле ввода не может быть пустым!";
            }
            // Проверка на число
            else if (!int.TryParse(textFromTextBox1, out value))
            {
                errorMessage.Content = "Введіть коректне число!!!";
            }
            else
            {
                // Проверка на 0
                if (value > 0)
                {
                   

                    ShowExample showExample = new ShowExample();

                    showExample.GetRows(textFromTextBox1);
                    showExample.GetColumns(textFromTextBox2);

                    showExample.CreateTextBox();
                    showExample.Zfunc();
                    //showExample.UpdateLabelContent(textFromTextBox1);
                    showExample.Show();

                    this.Close();
                }
                else
                {
                    errorMessage.Content = "нуль, або меньше нуля не може бути!!!";
                }
            }
        }
        private void Button_Up1(object sender, RoutedEventArgs e)
        {
            int value;
            if (int.TryParse(textBox1.Text, out value))
            {
                textBox1.Text = (value + 1).ToString();
            }
            else
            {
                errorMessage.Content = "Введіть коректне число!!!";
            }
        }
        private void Button_Down1(object sender, RoutedEventArgs e)
        {
            int value;
            if (int.TryParse(textBox1.Text, out value))
            {
                textBox1.Text = (value - 1).ToString();
            }
            else
            {
                errorMessage.Content = "Введіть коректне число!!!";
            }
        }
        private void Button_Up2(object sender, RoutedEventArgs e)
        {
            int value;
            if (int.TryParse(textBox2.Text, out value))
            {
                textBox2.Text = (value + 1).ToString();
            }
            else
            {
                errorMessage.Content = "Введіть коректне число!!!";
            }
        }

        private void Button_Down2(object sender, RoutedEventArgs e)
        {
            int value;
            if (int.TryParse(textBox2.Text, out value))
            {
                textBox2.Text = (value - 1).ToString();
            }
            else
            {
                errorMessage.Content = "Введіть коректне число!!!";
            }
        }
    }
}
