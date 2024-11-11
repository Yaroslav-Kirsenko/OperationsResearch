using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;

namespace OperationsResearch.Dual
{
    public partial class ShowExample : Window
    {
        public SavedElements savedElements = new SavedElements();

        public ShowExample()
        {
            InitializeComponent();
        }

        public ShowSamle showSamle = new ShowSamle();

        public static int rows = 0;
        public static int columns = 0;


        // Установка количества строк
        public void GetRows(string rowsStr)
        {
            rows = Convert.ToInt32(rowsStr);
            InitializeArray(); // Инициализация массива после установки количества строк
            InitializeArrayResult();
            InitializeArrayZ(); // Инициализация массива Z
            InitializeArraySign();


        }

        // Установка количества столбцов
        public void GetColumns(string columnsStr)
        {
            columns = Convert.ToInt32(columnsStr);
            InitializeArray(); // Инициализация массива после установки количества столбцов
            InitializeArrayResult();
            InitializeArrayZ(); // Инициализация массива Z
            InitializeArraySign();

        }


        // Метод для инициализации массива в savedElements
        private void InitializeArray()
        {
            savedElements.InitializeArray(rows, columns);

        }

        private void InitializeArrayResult()
        {
            savedElements.InitializeArrayResult(rows); // Указываем только количество столбцов
        }

        private void InitializeArrayZ()
        {
            savedElements.InitializeArrayZ(columns); // Указываем только количество столбцов
        }

        private void InitializeArraySign()
        {
            savedElements.InitializeArraySign(rows);
        }




        private bool ValidateTextBoxInput(TextBox textBox)
        {

            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
               textBox.Background = System.Windows.Media.Brushes.LightPink;
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Background = System.Windows.Media.Brushes.White; 
                return true;
            }

           
            if (int.TryParse(textBox.Text, out _))
            {
                textBox.Background = System.Windows.Media.Brushes.White; 
                return true;
            }
            else
            {
                textBox.Background = System.Windows.Media.Brushes.LightPink; 
                return false;
            }
        }

        private bool HasValidationErrors()
        {
            bool hasErrors = false;

            foreach (var child in textBoxContainer.Children)
            {
                if (child is TextBox textBox)
                {
                    
                    if (!ValidateTextBoxInput(textBox))
                    {
                        hasErrors = true;
                    }
                }
            }

            foreach (var child in textBoxContainerZ.Children)
            {
                if (child is TextBox textBox)
                {
                    if (!ValidateTextBoxInput(textBox))
                    {
                        hasErrors = true;
                    }
                }
            }

            if (hasErrors)
            {
                
                MessageBox.Show("Будь ласка, виправте всі помилки вводу перед переходом.", "Помилка вводу", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return hasErrors;
        }

        // Метод для создания основной таблицы с текстовыми полями, знаками и значениями
        public void CreateTextBox()
        {
            textBoxContainer.Children.Clear();
            textBoxContainer.RowDefinitions.Clear();
            textBoxContainer.ColumnDefinitions.Clear();

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
            Grid.SetColumn(signHeader, columns + 1);
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
            Grid.SetColumn(valueHeader, columns + 2);
            textBoxContainer.Children.Add(valueHeader);

            // Добавляем строки с номерами и полями ввода
            for (int i = 0; i < rows; i++)
            {
                textBoxContainer.RowDefinitions.Add(new RowDefinition());

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

                    int row = i;
                    int column = j;

                    textBox.TextChanged += (sender, e) =>
                    {
                        if (ValidateTextBoxInput(textBox) && int.TryParse(textBox.Text, out int result))
                        {
                            SavedElements.array[row,column] = result;
                        }
                        else
                        {
                            SavedElements.array[row,column] = 0;
                        }
                    };

                    Grid.SetRow(textBox, i + 1);
                    Grid.SetColumn(textBox, j + 1);
                    textBoxContainer.Children.Add(textBox);
                }

                ComboBox signComboBox = new ComboBox
                {
                    Width = 100,
                    ItemsSource = new List<string> { "=", "<=", ">=" },
                    SelectedIndex = 0, // Устанавливаем начальное значение
                    Margin = new Thickness(5),
                    Padding = new Thickness(5),
                    BorderThickness = new Thickness(1),
                    BorderBrush = System.Windows.Media.Brushes.Black
                };

                int rows = i;

                // Сохраняем начальное значение при создании ComboBox
                SavedElements.arraySign[rows] = signComboBox.SelectedItem.ToString();

                // Добавляем обработчик для дальнейших изменений
                signComboBox.SelectionChanged += (sender, e) =>
                {
                    if (signComboBox.SelectedItem != null)
                    {
                        SavedElements.arraySign[rows] = signComboBox.SelectedItem.ToString();
                    }
                    else
                    {
                        SavedElements.arraySign[rows] = "="; // Значение по умолчанию, если SelectedItem не выбран
                    }
                };

                Grid.SetRow(signComboBox, i + 1);
                Grid.SetColumn(signComboBox, columns + 1);
                textBoxContainer.Children.Add(signComboBox);

                TextBox valueTextBox = new TextBox
                {
                    BorderThickness = new Thickness(1),
                    BorderBrush = System.Windows.Media.Brushes.Black,
                    Padding = new Thickness(5),
                };



                valueTextBox.TextChanged += (sender, e) =>
                {
                    if (ValidateTextBoxInput(valueTextBox) && int.TryParse(valueTextBox.Text, out int result))
                    {
                        SavedElements.arrayResult[rows] = result;
                    }
                    else
                    {
                        SavedElements.arrayResult[rows] = 0;
                    }
                };

                // Сбрасываем цвет только при корректном значении и потере фокуса
                valueTextBox.LostFocus += (sender, e) =>
                {
                    if (ValidateTextBoxInput(valueTextBox))
                    {
                        valueTextBox.Background = System.Windows.Media.Brushes.White;
                    }
                };


                valueTextBox.PreviewLostKeyboardFocus += (sender, e) =>
                {
                    valueTextBox.Background = System.Windows.Media.Brushes.White; // Сбрасываем цвет фона при потере фокуса
                };

                Grid.SetRow(valueTextBox, i + 1);
                Grid.SetColumn(valueTextBox, columns + 2);
                textBoxContainer.Children.Add(valueTextBox);
            }
        }

        // Метод для создания таблицы для функции Z
        public void Zfunc()
        {
            textBoxContainerZ.Children.Clear();
            textBoxContainerZ.RowDefinitions.Clear();
            textBoxContainerZ.ColumnDefinitions.Clear();

            textBoxContainerZ.ShowGridLines = true;
            textBoxContainerZ.RowDefinitions.Add(new RowDefinition());
            textBoxContainerZ.ColumnDefinitions.Add(new ColumnDefinition());

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

                Grid.SetRow(zColumn, 0);
                Grid.SetColumn(zColumn, j + 1);
                textBoxContainerZ.Children.Add(zColumn);
            }

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
            Grid.SetColumn(extremumHeader, columns + 1);
            textBoxContainerZ.Children.Add(extremumHeader);

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

                int column = j;

                textBox.TextChanged += (sender, e) =>
                {
                    if (ValidateTextBoxInput(textBox) && int.TryParse(textBox.Text, out int result))
                    {
                        SavedElements.arrayZ[column] = result;
                    }
                    else
                    {
                        SavedElements.arrayZ[column] = 0;
                    }
                };


                textBox.LostFocus += (sender, e) =>
                {
                    if (ValidateTextBoxInput(textBox))
                    {
                        textBox.Background = System.Windows.Media.Brushes.White;
                    }
                };


                Grid.SetRow(textBox, 1);
                Grid.SetColumn(textBox, j + 1);
                textBoxContainerZ.Children.Add(textBox);
            }

            ComboBox extremumComboBox = new ComboBox
            {

                Width = 100,
                ItemsSource = new List<string> { "max", "min" },
                SelectedIndex = 0,
                Margin = new Thickness(5),
                Padding = new Thickness(5),
                BorderThickness = new Thickness(1),
                BorderBrush = System.Windows.Media.Brushes.Black
            };
            string value = extremumComboBox.SelectedItem.ToString();
            savedElements.InitializeExtremum(value);

            // Добавляем обработчик для дальнейших изменений
            extremumComboBox.SelectionChanged += (sender, e) =>
            {
                if (extremumComboBox.SelectedItem != null)
                {
                    SavedElements.Extremum = extremumComboBox.SelectedItem.ToString();
                }
            };


            Grid.SetRow(extremumComboBox, 1);
            Grid.SetColumn(extremumComboBox, columns + 1);

            textBoxContainerZ.Children.Add(extremumComboBox);
        }

        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            ColumAndRowsDual columAndRowsDual = new ColumAndRowsDual();

            columAndRowsDual.Show();
            this.Hide();
        }

        private void Button_Click_Next(object sender, RoutedEventArgs e)
        {
            if (HasValidationErrors()) { return; }



           ShowSamle showSamle = new ShowSamle();

            showSamle.GetRowsSamle(rows);
            showSamle.GetColumnsSamle(columns);


            SavedElements.ShowValues();
            SavedElements.ShowValuesRezult();
            SavedElements.ShowValuesZ();
            SavedElements.ShowValuesSign();
            SavedElements.ShowExtremum();


            showSamle.Show();
            this.Hide();
        }
    }
}
