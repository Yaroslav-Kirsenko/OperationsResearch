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


        //public void UpdateLabelContent(string content)
        //{
        //    // Предположим, что Label с именем "displayLabel"
        //    displayLabel.Content = content;
        //}


        public int rows = 0;
        public int columns = 0;

        public void GetRows(string rowsStr)
        {
            rows = Convert.ToInt32(rowsStr);
            Console.WriteLine(rows);
        }


        public void GetColumns(string columnsStr)
        {
            columns = Convert.ToInt32(columnsStr);
            Console.WriteLine(columns);
        }

        //public void CreateTextBox()
        //{
        //    // Очистим контейнер перед добавлением новых TextBox
        //    textBoxContainer.Children.Clear();

        //    for (int i = 0; i < rows; i++)
        //    {
        //        for (int j = 0; j < columns; j++)
        //        {
        //            // Создаем TextBox
        //            TextBox textBox = new TextBox();
        //            textBox.Width = 100;
        //            textBox.Height = 30;
        //            textBox.Margin = new Thickness(5); // Добавим отступы для красоты

        //            // Добавляем его в StackPanel
        //            textBoxContainer.Children.Add(textBox);
        //        }

        //    }
        //}

        public void CreateTextBox()
        {
            // Очистим контейнер перед добавлением новых элементов
            textBoxContainer.Children.Clear();
            textBoxContainer.RowDefinitions.Clear();
            textBoxContainer.ColumnDefinitions.Clear();

            // Создадим строку для заголовков столбцов (X1, X2, X3 и т.д.)
            textBoxContainer.RowDefinitions.Add(new RowDefinition());

            // Добавляем пустую ячейку для номера строк в первой колонке
            textBoxContainer.ColumnDefinitions.Add(new ColumnDefinition());

            // Добавляем заголовки столбцов
            for (int j = 0; j < columns; j++)
            {
                textBoxContainer.ColumnDefinitions.Add(new ColumnDefinition());

                // Создаем Label для заголовка столбца
                Label headerLabel = new Label();
                headerLabel.Content = $"X{j + 1}";
                headerLabel.HorizontalContentAlignment = HorizontalAlignment.Center;
                headerLabel.Width = 100;
                headerLabel.Height = 30;
                headerLabel.Margin = new Thickness(5);

                // Добавляем заголовок в первую строку
                Grid.SetRow(headerLabel, 0);
                Grid.SetColumn(headerLabel, j + 1);
                textBoxContainer.Children.Add(headerLabel);
            }

            // Добавляем строки с нумерацией и полями ввода
            for (int i = 0; i < rows; i++)
            {
                // Добавляем строку для текущей строки полей ввода
                textBoxContainer.RowDefinitions.Add(new RowDefinition());

                // Создаем Label для номера строки
                Label rowLabel = new Label();
                rowLabel.Content = $"{i + 1}";
                rowLabel.HorizontalContentAlignment = HorizontalAlignment.Center;
                rowLabel.Width = 100;
                rowLabel.Height = 30;
                rowLabel.Margin = new Thickness(5);

                // Добавляем номер строки в первую колонку
                Grid.SetRow(rowLabel, i + 1);
                Grid.SetColumn(rowLabel, 0);
                textBoxContainer.Children.Add(rowLabel);

                // Создаем TextBox для каждого столбца в текущей строке
                for (int j = 0; j < columns; j++)
                {
                    TextBox textBox = new TextBox();
                    textBox.Width = 100;
                    textBox.Height = 30;
                    textBox.Margin = new Thickness(5);

                    // Добавляем TextBox в текущую строку и столбец
                    Grid.SetRow(textBox, i + 1);
                    Grid.SetColumn(textBox, j + 1);
                    textBoxContainer.Children.Add(textBox);
                }
            }
        }

    }
}
