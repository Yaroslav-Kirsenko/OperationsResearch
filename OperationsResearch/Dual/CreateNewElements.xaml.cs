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

        //1
        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            // Увеличиваем количество столбцов
            columns++;
            index++;

            // Добавляем новую колонку для нового элемента
            textBoxContainer.ColumnDefinitions.Insert(columns - 1, new ColumnDefinition());

            // Создаем заголовок для нового столбца, например, "U" + номер
            Label headerLabel = new Label
            {
                Content = $"U{index}",
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                BorderThickness = new Thickness(1),
                BorderBrush = System.Windows.Media.Brushes.Black,
                Background = System.Windows.Media.Brushes.LightPink,
                Padding = new Thickness(5)
            };

            // Устанавливаем позицию заголовка нового столбца
            Grid.SetRow(headerLabel, 0);
            Grid.SetColumn(headerLabel, columns - 1); // Новый столбец перед столбцами "Знак" и "Значення"
            textBoxContainer.Children.Add(headerLabel);

            // Добавляем новый столбец с TextBox для каждой строки
            for (int i = 0; i < rows; i++)
            {
                TextBox textBox = new TextBox
                {
                    BorderThickness = new Thickness(1),
                    BorderBrush = System.Windows.Media.Brushes.Black,
                    Padding = new Thickness(5),
                    Text = "0" // Начальное значение или по необходимости
                };

                // Устанавливаем позицию TextBox в новом столбце
                Grid.SetRow(textBox, i + 1);
                Grid.SetColumn(textBox, columns - 1);
                textBoxContainer.Children.Add(textBox);
            }

            // Корректируем положение заголовков "Знак" и "Значення"
            foreach (var child in textBoxContainer.Children)
            {
                if (child is Label label)
                {
                    if ((string)label.Content == "Знак")
                    {
                        Grid.SetColumn(label, columns);
                    }
                    else if ((string)label.Content == "Значення")
                    {
                        Grid.SetColumn(label, columns + 1);
                    }
                }
            }

            // Перемещаем ComboBox и TextBox значений для каждой строки на соответствующие позиции
            for (int i = 0; i < rows; i++)
            {
                foreach (var child in textBoxContainer.Children)
                {
                    if (child is ComboBox comboBox && Grid.GetRow(comboBox) == i + 1 && Grid.GetColumn(comboBox) == columns - 2)
                    {
                        Grid.SetColumn(comboBox, columns);
                    }
                    else if (child is TextBox valueTextBox && Grid.GetRow(valueTextBox) == i + 1 && Grid.GetColumn(valueTextBox) == columns - 1)
                    {
                        Grid.SetColumn(valueTextBox, columns + 1);
                    }
                }
            }
        }


        //2
        //private void Button_Click_Add(object sender, RoutedEventArgs e)
        //{
        //    // Увеличиваем количество столбцов
        //    columns++;
        //    index++;

        //    // Обновляем сетку: сначала очищаем контейнер, а затем пересоздаем его полностью
        //    textBoxContainer.Children.Clear();
        //    textBoxContainer.ColumnDefinitions.Clear();

        //    // Пересоздаем заголовки столбцов (включая новый столбец "U")
        //    textBoxContainer.ColumnDefinitions.Add(new ColumnDefinition()); // Пустая колонка для номеров строк

        //    for (int j = 0; j < columns; j++)
        //    {
        //        textBoxContainer.ColumnDefinitions.Add(new ColumnDefinition());

        //        string headerText = j < columns - 1 ? $"X{j + 1}" : $"U{index}";
        //        Label headerLabel = new Label
        //        {
        //            Content = headerText,
        //            HorizontalContentAlignment = HorizontalAlignment.Center,
        //            VerticalAlignment = VerticalAlignment.Center,
        //            BorderThickness = new Thickness(1),
        //            BorderBrush = System.Windows.Media.Brushes.Black,
        //            Background = System.Windows.Media.Brushes.LightPink,
        //            Padding = new Thickness(5)
        //        };

        //        Grid.SetRow(headerLabel, 0);
        //        Grid.SetColumn(headerLabel, j + 1);
        //        textBoxContainer.Children.Add(headerLabel);
        //    }

        //    // Добавляем заголовки "Знак" и "Значення" в конце
        //    textBoxContainer.ColumnDefinitions.Add(new ColumnDefinition()); // Для столбца "Знак"
        //    textBoxContainer.ColumnDefinitions.Add(new ColumnDefinition()); // Для столбца "Значення"

        //    Label signHeader = new Label
        //    {
        //        Content = "Знак",
        //        HorizontalContentAlignment = HorizontalAlignment.Center,
        //        VerticalAlignment = VerticalAlignment.Center,
        //        BorderThickness = new Thickness(1),
        //        BorderBrush = System.Windows.Media.Brushes.Black,
        //        Background = System.Windows.Media.Brushes.LightPink,
        //        Padding = new Thickness(5)
        //    };
        //    Grid.SetRow(signHeader, 0);
        //    Grid.SetColumn(signHeader, columns + 1);
        //    textBoxContainer.Children.Add(signHeader);

        //    Label valueHeader = new Label
        //    {
        //        Content = "Значення",
        //        HorizontalContentAlignment = HorizontalAlignment.Center,
        //        VerticalAlignment = VerticalAlignment.Center,
        //        BorderThickness = new Thickness(1),
        //        BorderBrush = System.Windows.Media.Brushes.Black,
        //        Background = System.Windows.Media.Brushes.LightPink,
        //        Padding = new Thickness(5)
        //    };
        //    Grid.SetRow(valueHeader, 0);
        //    Grid.SetColumn(valueHeader, columns + 2);
        //    textBoxContainer.Children.Add(valueHeader);

        //    // Добавляем строки и элементы для каждой строки (включая новые столбцы)
        //    for (int i = 0; i < rows; i++)
        //    {
        //        textBoxContainer.RowDefinitions.Add(new RowDefinition());

        //        // Создаем номер строки
        //        Label rowLabel = new Label
        //        {
        //            Content = $"{i + 1}",
        //            HorizontalContentAlignment = HorizontalAlignment.Center,
        //            VerticalAlignment = VerticalAlignment.Center,
        //            BorderThickness = new Thickness(1),
        //            BorderBrush = System.Windows.Media.Brushes.Black,
        //            Background = System.Windows.Media.Brushes.LightPink,
        //            Padding = new Thickness(5)
        //        };
        //        Grid.SetRow(rowLabel, i + 1);
        //        Grid.SetColumn(rowLabel, 0);
        //        textBoxContainer.Children.Add(rowLabel);

        //        // Заполняем ячейки с существующими и новыми текстовыми полями
        //        for (int j = 0; j < columns; j++)
        //        {
        //            TextBox textBox = new TextBox
        //            {
        //                BorderThickness = new Thickness(1),
        //                BorderBrush = System.Windows.Media.Brushes.Black,
        //                Padding = new Thickness(5),
        //                Text = j < columns - 1 ? SavedElements.array[i][j].ToString() : "0" // Новая ячейка с "0"
        //            };

        //            Grid.SetRow(textBox, i + 1);
        //            Grid.SetColumn(textBox, j + 1);
        //            textBoxContainer.Children.Add(textBox);
        //        }

        //        // ComboBox для "Знак" со значениями
        //        ComboBox signComboBox = new ComboBox
        //        {
        //            Width = 100,
        //            ItemsSource = new List<string> { "=", "<=", ">=" },
        //            SelectedItem = SavedElements.arraySign[i],
        //            Margin = new Thickness(5),
        //            Padding = new Thickness(5),
        //            BorderThickness = new Thickness(1),
        //            BorderBrush = System.Windows.Media.Brushes.Black
        //        };

        //        int row = i; // Для обработчика события сохраняем индекс строки

        //        signComboBox.SelectionChanged += (sender, e) =>
        //        {
        //            if (signComboBox.SelectedItem.ToString() == ">=" || signComboBox.SelectedItem.ToString() == "<=")
        //            {
        //                for (int j = 0; j < columns; j++)
        //                {
        //                    SavedElements.array[row][j] = -SavedElements.array[row][j];
        //                }
        //                SavedElements.arrayResult[row] = -SavedElements.arrayResult[row];
        //                UpdateTextBoxesInRow(row);
        //            }
        //        };

        //        Grid.SetRow(signComboBox, i + 1);
        //        Grid.SetColumn(signComboBox, columns + 1);
        //        textBoxContainer.Children.Add(signComboBox);

        //        // TextBox для значений
        //        TextBox valueTextBox = new TextBox
        //        {
        //            IsReadOnly = true,
        //            BorderThickness = new Thickness(1),
        //            BorderBrush = System.Windows.Media.Brushes.Black,
        //            Padding = new Thickness(5),
        //            Text = SavedElements.arrayResult[i].ToString()
        //        };

        //        Grid.SetRow(valueTextBox, i + 1);
        //        Grid.SetColumn(valueTextBox, columns + 2);
        //        textBoxContainer.Children.Add(valueTextBox);
        //    }
        //}



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
        }
    }
}
