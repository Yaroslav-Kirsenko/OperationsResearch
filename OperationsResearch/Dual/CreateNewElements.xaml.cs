using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace OperationsResearch.Dual
{
    /// <summary>
    /// Логика взаимодействия для CreateNewElements.xaml
    /// </summary>
    public partial class CreateNewElements : Window
    {
        public CreateNewElements()
        {
            InitializeComponent();
        }

        public static int rows = 0;
        public static int columns = 0;
        public static int index = 0;

        // Установка количества строк
        public void GetRows(string rowsStr)
        {
            rows = Convert.ToInt32(rowsStr);
        }

        // Установка количества столбцов
        public void GetColumns(string columnsStr)
        {
            columns = Convert.ToInt32(columnsStr);
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

                for (int j = 0; j < columns; j++)
                {
                    TextBox textBox = new TextBox
                    {
                        IsReadOnly = true,
                        BorderThickness = new Thickness(1),
                        BorderBrush = System.Windows.Media.Brushes.Black,
                        Padding = new Thickness(5),
                        Text = SavedElements.array[i][j].ToString()
                    };

                    Grid.SetRow(textBox, i + 1);
                    Grid.SetColumn(textBox, j + 1);
                    textBoxContainer.Children.Add(textBox);
                }

                ComboBox signComboBox = new ComboBox
                {
                    Width = 100,
                    ItemsSource = new List<string> { "=", "<=", ">=" },
                    SelectedItem = SavedElements.arraySign[i], // Устанавливаем начальное значение
                    Margin = new Thickness(5),
                    Padding = new Thickness(5),
                    BorderThickness = new Thickness(1),
                    BorderBrush = System.Windows.Media.Brushes.Black
                };

                int row = i; // Сохраняем индекс строки для использования в обработчике события

                signComboBox.SelectionChanged += (sender, e) =>
                {
                    if (signComboBox.SelectedItem.ToString() == ">=" || signComboBox.SelectedItem.ToString() == "<=")
                    {
                        // Инвертируем все значения в строке
                        for (int j = 0; j < columns; j++)
                        {
                            SavedElements.array[row][j] = -SavedElements.array[row][j];
                        }

                        // Инвертируем значение только в строке row для массива arrayResult
                        SavedElements.arrayResult[row] = -SavedElements.arrayResult[row];

                        // Обновляем текстовые поля для отображения инвертированных значений
                        UpdateTextBoxesInRow(row);
                    }
                };

                Grid.SetRow(signComboBox, i + 1);
                Grid.SetColumn(signComboBox, columns + 1);
                textBoxContainer.Children.Add(signComboBox);

                TextBox valueTextBox = new TextBox
                {
                    IsReadOnly = true,
                    BorderThickness = new Thickness(1),
                    BorderBrush = System.Windows.Media.Brushes.Black,
                    Padding = new Thickness(5),
                    Text = SavedElements.arrayResult[i].ToString()
                };



                Grid.SetRow(valueTextBox, i + 1);
                Grid.SetColumn(valueTextBox, columns + 2);
                textBoxContainer.Children.Add(valueTextBox);
            }
        }


        // Метод для обновления текстовых полей в строке после изменения знака
        private void UpdateTextBoxesInRow(int row)
        {
            // Обновляем значения TextBox для основного массива
            for (int j = 0; j < columns; j++)
            {
                foreach (var child in textBoxContainer.Children)
                {
                    if (child is TextBox textBox &&
                        Grid.GetRow(textBox) == row + 1 && // Учитываем сдвиг для первой строки заголовков
                        Grid.GetColumn(textBox) == j + 1)
                    {
                        textBox.Text = SavedElements.array[row][j].ToString();
                        break;
                    }
                }
            }

            // Обновляем TextBox для значения из arrayResult
            foreach (var child in textBoxContainer.Children)
            {
                if (child is TextBox textBox &&
                    Grid.GetRow(textBox) == row + 1 &&
                    Grid.GetColumn(textBox) == columns + 2) // Столбец для значений `arrayResult`
                {
                    textBox.Text = SavedElements.arrayResult[row].ToString();
                    break;
                }
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
                    IsReadOnly = true,
                    BorderThickness = new Thickness(1),
                    BorderBrush = System.Windows.Media.Brushes.Black,
                    Padding = new Thickness(5),
                    Text = SavedElements.arrayZ[j].ToString()
                };


                Grid.SetRow(textBox, 1);
                Grid.SetColumn(textBox, j + 1);
                textBoxContainerZ.Children.Add(textBox);
            }

            ComboBox extremumComboBox = new ComboBox
            {
                Width = 100,
                ItemsSource = new List<string> { "max", "min" },
                SelectedItem = SavedElements.Extremum,
                Margin = new Thickness(5),
                Padding = new Thickness(5),
                BorderThickness = new Thickness(1),
                BorderBrush = System.Windows.Media.Brushes.Black
            };


            extremumComboBox.SelectionChanged += (sender, e) =>
            {
                if (extremumComboBox.SelectedItem != null)
                {

                    for (int j = 0; j < columns; j++)
                    {
                        SavedElements.arrayZ[j] = -SavedElements.arrayZ[j];
                    }

                    UpdateTextBoxesInZRow();
                }
            };

            Grid.SetRow(extremumComboBox, 1);
            Grid.SetColumn(extremumComboBox, columns + 1);

            textBoxContainerZ.Children.Add(extremumComboBox);
        }

        private void UpdateTextBoxesInZRow()
        {
            for (int j = 0; j < columns; j++)
            {
                foreach (var child in textBoxContainerZ.Children)
                {
                    if (child is TextBox textBox &&
                        Grid.GetRow(textBox) == 1 &&
                        Grid.GetColumn(textBox) == j + 1)
                    {
                        textBox.Text = SavedElements.arrayZ[j].ToString();
                        break;
                    }
                }
            }
        }



        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            ShowSamle showSamle = new ShowSamle();

            showSamle.Show();

            this.Hide();
        }

        private void Button_Click_Next(object sender, RoutedEventArgs e)
        {
            SavedElements.ShowValues();
            SavedElements.ShowValuesRezult();
            SavedElements.ShowValuesZ();
            SavedElements.ShowValuesSign();
            SavedElements.ShowExtremum();


    

            AddNewElements addNewElements = new AddNewElements();

            addNewElements.GetRows(rows);
            addNewElements.GetColumns(columns);

            addNewElements.CreateTextBox();
            addNewElements.Zfunc();

            addNewElements.Show();

            this.Hide();
        }
    }
}
