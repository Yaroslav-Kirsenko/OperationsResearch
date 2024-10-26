using System;
using System.Collections.Generic;
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

        public ShowSamle showSamle = new ShowSamle();

        public int rows = 0;
        public int columns = 0;

        // Установка количества строк
        public void GetRows(string rowsStr)
        {
            rows = Convert.ToInt32(rowsStr);
            //Console.WriteLine(rows);
        }

        // Установка количества столбцов
        public void GetColumns(string columnsStr)
        {
            columns = Convert.ToInt32(columnsStr);
            //Console.WriteLine(columns);
        }

       

        

        // Метод для создания основной таблицы с текстовыми полями, знаками и значениями
        public void CreateTextBox()
        {
           

            //textBoxContainer.Children.Clear();
            //textBoxContainer.RowDefinitions.Clear();
            //textBoxContainer.ColumnDefinitions.Clear();

            // Включаем отображение линий сетки
            textBoxContainer.ShowGridLines = true;

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
                    VerticalAlignment = VerticalAlignment.Center,
                    BorderThickness = new Thickness(1),
                    BorderBrush = System.Windows.Media.Brushes.Black,
                    Background = System.Windows.Media.Brushes.LightPink,
                    Padding = new Thickness(5)

                    
                };

                showSamle.GetValueLabelX(headerLabel); ///////////////////////////////////////////////////////

                Grid.SetRow(headerLabel, 0);
                Grid.SetColumn(headerLabel, j + 1);
                textBoxContainer.Children.Add(headerLabel);
            }

            // Добавляем заголовки для столбцов "Знак" и "Значення"
            textBoxContainer.ColumnDefinitions.Add(new ColumnDefinition()); // Столбец для знаков
            textBoxContainer.ColumnDefinitions.Add(new ColumnDefinition()); // Столбец для значений

            Label signHeader = new Label
            {
                Content = "Знак",
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                BorderThickness = new Thickness(1),
                BorderBrush = System.Windows.Media.Brushes.Black,
                Background = System.Windows.Media.Brushes.LightPink,
                Padding = new Thickness(5)
            };

            Grid.SetRow(signHeader, 0);
            Grid.SetColumn(signHeader, columns + 1); // Добавляем в колонку для знаков
            textBoxContainer.Children.Add(signHeader);

            Label valueHeader = new Label
            {
                Content = "Значення",
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                BorderThickness = new Thickness(1),
                BorderBrush = System.Windows.Media.Brushes.Black,
                Background = System.Windows.Media.Brushes.LightPink,
                Padding = new Thickness(5)
            };

            Grid.SetRow(valueHeader, 0);
            Grid.SetColumn(valueHeader, columns + 2); // Добавляем в колонку для значений
            textBoxContainer.Children.Add(valueHeader);

            // Добавляем строки с номерами и полями ввода
            for (int i = 0; i < rows; i++)
            {
                textBoxContainer.RowDefinitions.Add(new RowDefinition());

                // Номер строки
                Label rowLabel = new Label
                {
                    Content = $"{i + 1}",
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    BorderThickness = new Thickness(1),
                    BorderBrush = System.Windows.Media.Brushes.Black,
                    Background = System.Windows.Media.Brushes.LightPink,
                    Padding = new Thickness(5)
                };

                Grid.SetRow(rowLabel, i + 1);
                Grid.SetColumn(rowLabel, 0);
                textBoxContainer.Children.Add(rowLabel);

                // Поля для ввода значений (X1, X2 и т.д.)
                for (int j = 0; j < columns; j++)
                {
                    TextBox textBox = new TextBox
                    {
                        BorderThickness = new Thickness(1),
                        BorderBrush = System.Windows.Media.Brushes.Black,
                        Padding = new Thickness(5),
                    };

                    Grid.SetRow(textBox, i + 1);
                    Grid.SetColumn(textBox, j + 1);
                    textBoxContainer.Children.Add(textBox);
                }

                // Добавляем выпадающий список для знаков
                ComboBox signComboBox = new ComboBox
                {
                    Width = 100,
                    ItemsSource = new List<string> { "=", "<=", ">=" }, // Пример опций
                    SelectedIndex = 0, // Значение по умолчанию
                    Margin = new Thickness(5),
                    Padding = new Thickness(5),
                    BorderThickness = new Thickness(1),
                    BorderBrush = System.Windows.Media.Brushes.Black
                };

                Grid.SetRow(signComboBox, i + 1);
                Grid.SetColumn(signComboBox, columns + 1); // Добавляем ComboBox после последнего столбца
                textBoxContainer.Children.Add(signComboBox);

                // Добавляем текстовое поле для значений
                TextBox valueTextBox = new TextBox
                {
                    BorderThickness = new Thickness(1),
                    BorderBrush = System.Windows.Media.Brushes.Black,
                    Padding = new Thickness(5),
                };

                Grid.SetRow(valueTextBox, i + 1);
                Grid.SetColumn(valueTextBox, columns + 2); // Добавляем TextBox для значений
                textBoxContainer.Children.Add(valueTextBox);
            }
        }

        // Метод для создания таблицы для функции Z
        public void Zfunc()
        {
            //textBoxContainerZ.Children.Clear();
            //textBoxContainerZ.RowDefinitions.Clear();
            //textBoxContainerZ.ColumnDefinitions.Clear();

            // Включаем отображение линий сетки
            textBoxContainerZ.ShowGridLines = true;

            // Создаем строку для заголовков столбцов (X1, X2 и т.д.)
            textBoxContainerZ.RowDefinitions.Add(new RowDefinition());
            textBoxContainerZ.ColumnDefinitions.Add(new ColumnDefinition()); // Пустая колонка для Z=

            for (int j = 0; j < columns; j++)
            {
                textBoxContainerZ.ColumnDefinitions.Add(new ColumnDefinition());

                Label zColumn = new Label
                {
                    Content = $"X{j + 1}",
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    BorderThickness = new Thickness(1),
                    BorderBrush = System.Windows.Media.Brushes.Black,
                    Background = System.Windows.Media.Brushes.LightPink,
                    Padding = new Thickness(5)
                };
                showSamle.GetValueZX(zColumn);///////////////////////////////////////////////////////////////////

                Grid.SetRow(zColumn, 0);
                Grid.SetColumn(zColumn, j + 1);
                textBoxContainerZ.Children.Add(zColumn);
            }

            // Добавляем колонку для экстремума
            textBoxContainerZ.ColumnDefinitions.Add(new ColumnDefinition());

            Label extremumHeader = new Label
            {
                Content = "Экстремум",
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                BorderThickness = new Thickness(1),
                BorderBrush = System.Windows.Media.Brushes.Black,
                Background = System.Windows.Media.Brushes.LightPink,
                Padding = new Thickness(5)
            };

            Grid.SetRow(extremumHeader, 0);
            Grid.SetColumn(extremumHeader, columns + 1); // Добавляем в последнюю колонку
            textBoxContainerZ.Children.Add(extremumHeader);

            // Добавляем строку для функции Z
            textBoxContainerZ.RowDefinitions.Add(new RowDefinition());

            Label zRowLabel = new Label
            {
                Content = "Z = ",
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                BorderThickness = new Thickness(1),
                BorderBrush = System.Windows.Media.Brushes.Black,
                Background = System.Windows.Media.Brushes.LightPink,
                Padding = new Thickness(5)
            };

            Grid.SetRow(zRowLabel, 1);
            Grid.SetColumn(zRowLabel, 0);

            textBoxContainerZ.Children.Add(zRowLabel);

            for (int j = 0; j < columns; j++)
            {
                TextBox textBox = new TextBox
                {
                    BorderThickness = new Thickness(1),
                    BorderBrush = System.Windows.Media.Brushes.Black,
                    Padding = new Thickness(5),
                };

                Grid.SetRow(textBox, 1);
                Grid.SetColumn(textBox, j + 1);
                textBoxContainerZ.Children.Add(textBox);
            }

            // Добавляем выпадающий список для выбора экстремума (max/min)
            ComboBox extremumComboBox = new ComboBox
            {
                Width = 100,
                ItemsSource = new List<string> { "max", "min" }, // Пример опций
                SelectedIndex = 0, // Значение по умолчанию
                Margin = new Thickness(5),
                Padding = new Thickness(5),
                BorderThickness = new Thickness(1),
                BorderBrush = System.Windows.Media.Brushes.Black
            };

            Grid.SetRow(extremumComboBox, 1); // Под функцией Z
            Grid.SetColumn(extremumComboBox, columns + 1); // В последнем столбце для экстремума

            textBoxContainerZ.Children.Add(extremumComboBox);
     
        }
        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            ColumAndRowsDual ColumAndRowsDual = new ColumAndRowsDual();

            ColumAndRowsDual.Show();

            this.Hide();
        }

        private void Button_Click_Next(object sender, RoutedEventArgs e)
        {

            showSamle.Show();

            this.Hide();
        }
    }
}
