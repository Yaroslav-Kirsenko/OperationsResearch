using System.Reflection.Emit;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

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
            int value;

            // Проверяем, является ли введённый текст числом
            if (int.TryParse(textFromTextBox1, out value))
            {

                if (value > 0)
                {
                    ShowExample showExample = new ShowExample();
                    showExample.UpdateLabelContent(textFromTextBox1);
                    showExample.Show();

                    this.Close();
                }
                else
                {
                    errorMessage.Content = "нуль, або меньше нуля не може бути!!!";
                }
            }
            else
            {
                errorMessage.Content = "Введіть коректне число!!!";
            }
        }

        private void Button_Up1(object sender, RoutedEventArgs e)
        {
            int value;
            if (int.TryParse(textBox1.Text, out value)) // проверка корректности ввода
            {
                textBox1.Text = (value + 1).ToString(); // увеличение на 1 и преобразование обратно в строку
            }
            else
            {
                errorMessage.Content = "Введіть коректне число!!!";
            }
        }

        private void Button_Down1(object sender, RoutedEventArgs e)
        {
            int value;
            if (int.TryParse(textBox1.Text, out value)) // проверка корректности ввода
            {
                textBox1.Text = (value - 1).ToString(); // увеличение на 1 и преобразование обратно в строку
            }
            else
            {
                errorMessage.Content = "Введіть коректне число!!!";
            }
        }

        private void Button_Up2(object sender, RoutedEventArgs e)
        {
            int value;
            if (int.TryParse(textBox2.Text, out value)) // проверка корректности ввода
            {
                textBox2.Text = (value + 1).ToString(); // увеличение на 1 и преобразование обратно в строку
            }
            else
            {
                errorMessage.Content = "Введіть коректне число!!!";
            }
        }

        private void Button_Down2(object sender, RoutedEventArgs e)
        {
            int value;
            if (int.TryParse(textBox2.Text, out value)) // проверка корректности ввода
            {
                textBox2.Text = (value - 1).ToString(); // увеличение на 1 и преобразование обратно в строку
            }
            else
            {

                errorMessage.Content = "Введіть коректне число!!!";
            }
        }
    }
}
