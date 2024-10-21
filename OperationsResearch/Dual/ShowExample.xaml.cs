using System;
using System.Windows;
using System.Windows.Controls;

namespace OperationsResearch.Dual
{
    public partial class ShowExample : Window
    {
        public ShowExample()
        {
            InitializeComponent();
        }

        public int rows = 0;
        public int columns = 0;

        // Установка количества строк
        public void GetRows(string rowsStr)
        {
            rows = Convert.ToInt32(rowsStr);
            Console.WriteLine(rows);
        }

        // Установка количества столбцов
        public void GetColumns(string columnsStr)
        {
            columns = Convert.ToInt32(columnsStr);
            Console.WriteLine(columns);
        }

        // Метод для создания таблицы для функции Z
        public void Zfunc()
        {
            textBoxContainerZ.Children.Clear();
            textBoxContainerZ.RowDefinitions.Clear();
            textBoxContainerZ.ColumnDefinitions.Clear();

            // Создаем строку для заголовков столбцов (X1, X2, и т.д.)
            textBoxContainerZ.RowDefinitions.Add(new RowDefinition());
            textBoxContainerZ.ColumnDefinitions.Add(new ColumnDefinition());

            for (int j = 0; j < columns; j++)
            {
                textBoxContainerZ.ColumnDefinitions.Add(new ColumnDefinition());

                Label zColumn = new Label
                {
                    Content = $"X{j + 1}",
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    Width = 100,
                    Height = 30,
                    Margin = new Thickness(5)
                };

                Grid.SetRow(zColumn, 0);
                Grid.SetColumn(zColumn, j + 1);
                textBoxContainerZ.Children.Add(zColumn);
            }

            // Добавляем строку для функции Z
            textBoxContainerZ.RowDefinitions.Add(new RowDefinition());

            Label zRowLabel = new Label
            {
                Content = "Z=",
                HorizontalContentAlignment = HorizontalAlignment.Center,
                Width = 100,
                Height = 30,
                Margin = new Thickness(5)
            };

            Grid.SetColumn(zRowLabel, 0);
            textBoxContainerZ.Children.Add(zRowLabel);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    TextBox textBox = new TextBox
                    {
                        Width = 100,
                        Height = 30,
                        Margin = new Thickness(5)
                    };
                    Grid.SetRow(textBox, i + 1);
                    Grid.SetColumn(textBox, j + 1);
                    textBoxContainerZ.Children.Add(textBox);

                }
            }
        }

        // Метод для создания основной таблицы с текстовыми полями
        public void CreateTextBox()
        {
            textBoxContainer.Children.Clear();
            textBoxContainer.RowDefinitions.Clear();
            textBoxContainer.ColumnDefinitions.Clear();

            // Создаем строку для заголовков столбцов (X1, X2 и т.д.)
            textBoxContainer.RowDefinitions.Add(new RowDefinition());
            textBoxContainer.ColumnDefinitions.Add(new ColumnDefinition()); // Пустая ячейка для номера строки

            for (int j = 0; j < columns; j++)
            {
                textBoxContainer.ColumnDefinitions.Add(new ColumnDefinition());

                Label headerLabel = new Label
                {
                    Content = $"X{j + 1}",
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    Width = 100,
                    Height = 30,
                    Margin = new Thickness(5)
                };

                Grid.SetRow(headerLabel, 0);
                Grid.SetColumn(headerLabel, j + 1);
                textBoxContainer.Children.Add(headerLabel);
            }

            // Добавляем строки с номерами и полями ввода
            for (int i = 0; i < rows; i++)
            {
                textBoxContainer.RowDefinitions.Add(new RowDefinition());

                // Номер строки
                Label rowLabel = new Label
                {
                    Content = $"{i + 1}",
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    Width = 100,
                    Height = 30,
                    Margin = new Thickness(5)
                };

                Grid.SetRow(rowLabel, i + 1);
                Grid.SetColumn(rowLabel, 0);
                textBoxContainer.Children.Add(rowLabel);

                // Поля для ввода значений (X1, X2 и т.д.)
                for (int j = 0; j < columns; j++)
                {
                    TextBox textBox = new TextBox
                    {
                        Width = 100,
                        Height = 30,
                        Margin = new Thickness(5)
                    };

                    Grid.SetRow(textBox, i + 1);
                    Grid.SetColumn(textBox, j + 1);
                    textBoxContainer.Children.Add(textBox);
                }
            }
        }
    }
}
