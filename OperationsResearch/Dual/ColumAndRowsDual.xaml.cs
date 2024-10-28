
using System.Windows;
using System.Windows.Controls;


namespace OperationsResearch.Dual
{
    /// <summary>
    /// Логика взаимодействия для ColumAndRowsDual.xaml
    /// </summary>
    public partial class ColumAndRowsDual : Window
    {

        public static string savedTextBox1Value = "0";
        public static string savedTextBox2Value = "0";

        public ColumAndRowsDual()
        {
            InitializeComponent();

            textBox1.Text = savedTextBox1Value;
            textBox2.Text = savedTextBox2Value;
        }

        public ShowExample showExample = new ShowExample();
        public ShowSamle showSamle = new ShowSamle();

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e) { }
        private void textBox2_TextChanged(object sender, TextChangedEventArgs e) { }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string textFromTextBox1 = textBox1.Text;
            string textFromTextBox2 = textBox2.Text;
            int value1;
            int value2;

            // Проверка на строка
            if (string.IsNullOrEmpty(textFromTextBox1) && string.IsNullOrEmpty(textFromTextBox2))
            {
                errorMessage.Content = "Поле не може бути пустим!!!";
            }
            // Проверка на число
            else if (!int.TryParse(textFromTextBox1, out value1))
            {
                errorMessage.Content = "Введіть коректне число!!!";
            }
            else if (!int.TryParse(textFromTextBox2, out value2))
            {
                errorMessage.Content = "Введіть коректне число!!!";
            }
            else
            {
                // Проверка на 0
                if (value1 > 1 && value2 > 1)
                {
                    showExample.GetRows(textFromTextBox1);
                    showExample.GetColumns(textFromTextBox2);

                    //showSamle.GetRowsSamle(textFromTextBox1);
                    //showSamle.GetColumnsSamle(textFromTextBox2);

                    showExample.CreateTextBox();
                    showExample.Zfunc();
                    showExample.Show();

                    savedTextBox1Value = textBox1.Text;
                    savedTextBox2Value = textBox2.Text;

                    this.Hide();
                }
                else
                {
                    errorMessage.Content = "нуль, або меньше одиниці не може бути!!!";
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

        private void Button_Click_Exet(object sender, RoutedEventArgs e)
        {
            savedTextBox1Value = textBox1.Text;
            savedTextBox2Value = textBox2.Text;

            MainWindow mainWindow = new MainWindow();

            mainWindow.Show();

            this.Hide();
        }
    }
}
