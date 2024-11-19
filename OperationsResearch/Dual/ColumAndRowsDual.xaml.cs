using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace OperationsResearch.Dual
{
    public partial class ColumAndRowsDual : Window
    {
        public static string savedTextBox1Value = "2";
        public static string savedTextBox2Value = "2";

        public ColumAndRowsDual()
        {
            InitializeComponent();
            this.Closing += MainWindow_Closing; 

            textBox1.Text = savedTextBox1Value;
            textBox2.Text = savedTextBox2Value;
        }

        public ShowExample showExample = new ShowExample();
        public ShowSamle showSamle = new ShowSamle();

        // Метод для обработки изменения текста в textBox1
        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidateTextBox(textBox1);
        }

        // Метод для обработки изменения текста в textBox2
        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidateTextBox(textBox2);
        }

        private bool ValidateTextBox(TextBox textBox)
        {
            // Проверка на пустое поле
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Background = Brushes.LightPink;
                return false;
            }

            // Проверка на корректное числовое значение и на значение больше 1
            if (int.TryParse(textBox.Text, out int value))
            {
                textBox.Background = Brushes.White;
                return true;
            }
            else
            {
                textBox.Background = Brushes.LightPink;
                return false;
            }
        }

        private bool HasValidationErrors()
        {
            bool hasError = false;

            // Проверка textBox1
            if (!ValidateTextBox(textBox1) && !ValidateTextBox(textBox2))
            {

                MessageBox.Show("Будь ласка, виправте всі помилки вводу перед переходом.", "Помилка вводу", MessageBoxButton.OK, MessageBoxImage.Warning);
                hasError = true;
            }
            return hasError;
        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (HasValidationErrors()) { return; }


            bool isTextBox1Valid = ValidateTextBox(textBox1);
            bool isTextBox2Valid = ValidateTextBox(textBox2);

            if (!isTextBox1Valid || !isTextBox2Valid)
            {
                return;
            }

            int value1 = int.Parse(textBox1.Text);
            int value2 = int.Parse(textBox2.Text);
            if (value1 > 1 && value2 > 1)
            {
                showExample.GetRows(textBox1.Text);
                showExample.GetColumns(textBox2.Text);

                showExample.CreateTextBox();
                showExample.Zfunc();
                showExample.Show();

                savedTextBox1Value = textBox1.Text;
                savedTextBox2Value = textBox2.Text;
                this.Hide();
            }
            else
            {
                textBox1.Background = Brushes.LightPink;
                textBox2.Background = Brushes.LightPink;
                MessageBox.Show("Будь ласка, виправте всі помилки вводу перед переходом.", "Помилка вводу", MessageBoxButton.OK, MessageBoxImage.Warning);
            }


        }

        private void Button_Up1(object sender, RoutedEventArgs e)
        {
            if (ValidateTextBox(textBox1))
            {
                textBox1.Text = (int.Parse(textBox1.Text) + 1).ToString();
            }
        }

        private void Button_Down1(object sender, RoutedEventArgs e)
        {
            if (ValidateTextBox(textBox1))
            {
                int currentValue = int.Parse(textBox1.Text);
                if (currentValue > 1) textBox1.Text = (currentValue - 1).ToString();
            }
        }

        private void Button_Up2(object sender, RoutedEventArgs e)
        {
            if (ValidateTextBox(textBox2))
            {
                textBox2.Text = (int.Parse(textBox2.Text) + 1).ToString();
            }
        }

        private void Button_Down2(object sender, RoutedEventArgs e)
        {
            if (ValidateTextBox(textBox2))
            {
                int currentValue = int.Parse(textBox2.Text);
                if (currentValue > 1) textBox2.Text = (currentValue - 1).ToString();
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

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
