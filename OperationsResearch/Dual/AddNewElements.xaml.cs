using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace OperationsResearch.Dual
{
    public partial class AddNewElements : Window
    {


        public AddNewElements()
        {
            InitializeComponent();

        }
        

        public SavedElements savedElements = new SavedElements();


    

        public static int rows = 0;
        public static int columns = 0;
        public static int index = 0;

        public static string strRows = "";
        public static string strColumns = "";

        // Двумерный массив для хранения значений дополнительных переменных U
        public static double[,] additionalVariables;

        public static double[,] fullArray;


        // Установка количества строк
        public void GetRows(int rowsStr)
        {
            rows = Convert.ToInt32(rowsStr);
            InitializeAdditionalVariables();
            InitializeFullArray();
            additionalVariables = new double[rows, columns];
        }


        // Установка количества столбцов
        public void GetColumns(int columnsStr)
        {
            columns = Convert.ToInt32(columnsStr);
            InitializeAdditionalVariables();
            InitializeFullArray();
            additionalVariables = new double[rows, 0]; // Изначально нет дополнительных переменных

        }


        private void InitializeFullArray()
        {
            savedElements.InitializeFullArray(rows, columns); // Указываем только количество столбцов
        }

        private void InitializeAdditionalVariables()
        {
            savedElements.InitializeAdditionalVariables(rows, columns); // Указываем только количество столбцов
        }

        public static void SetRows(int rowsStr)
        {
            strRows = Convert.ToString(rowsStr);
        }

        public static void SetColumns(int columnsStr)
        {
            strColumns = Convert.ToString(columnsStr);
        }



        // Метод для создания основной таблицы с текстовыми полями, знаками и значениями
        public void CreateTextBox()
        {

            textBoxContainer.Children.Clear();
            textBoxContainer.RowDefinitions.Clear();
            textBoxContainer.ColumnDefinitions.Clear();
            textBoxContainer.ShowGridLines = false;

            // Заголовки столбцов для X переменных
            textBoxContainer.RowDefinitions.Add(new RowDefinition());
            textBoxContainer.ColumnDefinitions.Add(new ColumnDefinition());

            for (int j = 0; j < columns; j++)
            {
                textBoxContainer.ColumnDefinitions.Add(new ColumnDefinition());
                string header = $"X{j + 1}";
                Label headerLabel = CreateHeaderLabel(header, j + 1);
                textBoxContainer.Children.Add(headerLabel);
            }

            // Добавление заголовков для дополнительных переменных U
            for (int k = 0; k < additionalVariables.GetLength(1); k++)
            {
                textBoxContainer.ColumnDefinitions.Add(new ColumnDefinition());
                string header = $"U{index - additionalVariables.GetLength(1) + k + 1}";
                Label headerLabel = CreateHeaderLabel(header, columns + k + 1);
                textBoxContainer.Children.Add(headerLabel);
            }
            AddHeadersForSignAndValues(columns + additionalVariables.GetLength(1));
            AddRowsWithElements();
        }

        // Метод для создания таблицы для функции Z
        public void Zfunc()
        {
            textBoxContainerZ.Children.Clear();
            textBoxContainerZ.RowDefinitions.Clear();
            textBoxContainerZ.ColumnDefinitions.Clear();
            textBoxContainerZ.ShowGridLines = false;

            // Создаем строку заголовков для функции Z
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
                    BorderBrush = Brushes.Black,
                    Background = Brushes.SkyBlue,
                    Padding = new Thickness(5)
                };

                Grid.SetRow(zColumn, 0);
                Grid.SetColumn(zColumn, j + 1);
                textBoxContainerZ.Children.Add(zColumn);
            }

            // Добавляем столбцы для дополнительных переменных U
            for (int k = 0; k < additionalVariables.GetLength(1); k++)
            {
                textBoxContainerZ.ColumnDefinitions.Add(new ColumnDefinition());

                Label uColumn = new Label
                {
                    Content = $"U{index - additionalVariables.GetLength(1) + k + 1}",
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    BorderThickness = new Thickness(1),
                    BorderBrush = Brushes.Black,
                    Background = Brushes.SkyBlue,
                    Padding = new Thickness(5)
                };

                Grid.SetRow(uColumn, 0);
                Grid.SetColumn(uColumn, columns + k + 1);
                textBoxContainerZ.Children.Add(uColumn);
            }

            textBoxContainerZ.ColumnDefinitions.Add(new ColumnDefinition());

            Label extremumHeader = new Label
            {
                Content = "Экстремум",
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                BorderThickness = new Thickness(1),
                BorderBrush = Brushes.Black,
                Background = Brushes.SkyBlue,
                Padding = new Thickness(5)
            };

            Grid.SetRow(extremumHeader, 0);
            Grid.SetColumn(extremumHeader, columns + additionalVariables.GetLength(1) + 1);
            textBoxContainerZ.Children.Add(extremumHeader);

            textBoxContainerZ.RowDefinitions.Add(new RowDefinition());

            Label zRowLabel = new Label
            {
                Content = "Z = ",
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                BorderThickness = new Thickness(1),
                BorderBrush = Brushes.Black,
                Background = Brushes.SkyBlue,
                Padding = new Thickness(5)
            };

            Grid.SetRow(zRowLabel, 1);
            Grid.SetColumn(zRowLabel, 0);
            textBoxContainerZ.Children.Add(zRowLabel);

            // Текстовые поля для коэффициентов Z функции для X переменных
            for (int j = 0; j < columns; j++)
            {
                TextBox textBox = new TextBox
                {
                    IsReadOnly = true,
                    BorderThickness = new Thickness(1),
                    BorderBrush = Brushes.Black,
                    Padding = new Thickness(5),
                    Text = SavedElements.arrayZ[j].ToString()
                };

                Grid.SetRow(textBox, 1);
                Grid.SetColumn(textBox, j + 1);
                textBoxContainerZ.Children.Add(textBox);
            }

            // Текстовые поля для коэффициентов Z функции для U переменных
            for (int k = 0; k < additionalVariables.GetLength(1); k++)
            {
                TextBox textBox = new TextBox
                {
                    IsReadOnly = false,
                    BorderThickness = new Thickness(1),
                    BorderBrush = Brushes.Black,
                    Padding = new Thickness(5),
                    Text = "0" // По умолчанию значение для U
                };

                int colIndex = columns + k + 1;
                Grid.SetRow(textBox, 1);
                Grid.SetColumn(textBox, colIndex);
                textBoxContainerZ.Children.Add(textBox);
            }

            ComboBox extremumComboBox = new ComboBox
            {
                ItemsSource = new List<string> { "max", "min" },
                SelectedItem = SavedElements.Extremum,
                Padding = new Thickness(5),
                BorderThickness = new Thickness(1),
                BorderBrush = System.Windows.Media.Brushes.Black,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Margin = new Thickness(0)
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
            Grid.SetColumn(extremumComboBox, columns + additionalVariables.GetLength(1) + 1);
            textBoxContainerZ.Children.Add(extremumComboBox);
        }

        private void UpdateTextBoxesInZRow()
        {
            for (int j = 0; j < columns; j++)
            {
                foreach (var child in textBoxContainerZ.Children)
                {
                    if (child is TextBox textBox && Grid.GetRow(textBox) == 1 && Grid.GetColumn(textBox) == j + 1)
                    {
                        textBox.Text = SavedElements.arrayZ[j].ToString();
                        break;
                    }
                }
            }
        }

        private void AddHeadersForSignAndValues(int columnCount)
        {
            textBoxContainer.ColumnDefinitions.Add(new ColumnDefinition());
            textBoxContainer.ColumnDefinitions.Add(new ColumnDefinition());

            Label signHeader = CreateHeaderLabel("Знак", columnCount + 1);
            Label valueHeader = CreateHeaderLabel("Значення", columnCount + 2);

            textBoxContainer.Children.Add(signHeader);
            textBoxContainer.Children.Add(valueHeader);
        }

        private Label CreateHeaderLabel(string content, int columnIndex)
        {
            Label headerLabel = new Label
            {
                Content = content,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                BorderThickness = new Thickness(1),
                BorderBrush = Brushes.Black,
                Background = Brushes.SkyBlue,
                Padding = new Thickness(5)
            };

            Grid.SetRow(headerLabel, 0);
            Grid.SetColumn(headerLabel, columnIndex);
            return headerLabel;
        }

        private void AddRowsWithElements()
        {
            for (int i = 0; i < rows; i++)
            {
                textBoxContainer.RowDefinitions.Add(new RowDefinition());

                Label rowLabel = new Label
                {
                    Content = $"{i + 1}",
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    BorderThickness = new Thickness(1),
                    BorderBrush = Brushes.Black,
                    Background = Brushes.SkyBlue,
                    Padding = new Thickness(5)
                };
                Grid.SetRow(rowLabel, i + 1);
                Grid.SetColumn(rowLabel, 0);
                textBoxContainer.Children.Add(rowLabel);

                // Добавляем значения из основного массива SavedElements
                for (int j = 0; j < columns; j++)
                {
                    TextBox textBox = new TextBox
                    {
                        IsReadOnly = true,
                        BorderThickness = new Thickness(1),
                        BorderBrush = Brushes.Black,
                        Padding = new Thickness(5),
                        Text = SavedElements.array[i, j].ToString()
                    };

                    Grid.SetRow(textBox, i + 1);
                    Grid.SetColumn(textBox, j + 1);
                    textBoxContainer.Children.Add(textBox);
                }

                // Добавляем значения дополнительных переменных U
                for (int k = 0; k < additionalVariables.GetLength(1); k++)
                {
                    TextBox textBox = new TextBox
                    {
                        IsReadOnly = false, // Только U переменные можно изменять
                        BorderThickness = new Thickness(1),
                        BorderBrush = Brushes.Black,
                        Padding = new Thickness(5),
                        Text = additionalVariables[i, k].ToString()
                    };


                    int row = i;
                    int col = k;

                    textBox.TextChanged += (sender, e) =>
                    {
                        if (int.TryParse(textBox.Text, out int value))
                        {
                            SavedElements.additionalVariables[row, col] = value;

                        }
                    };

                    Grid.SetRow(textBox, i + 1);
                    Grid.SetColumn(textBox, columns + k + 1);
                    textBoxContainer.Children.Add(textBox);
                }

                ComboBox signComboBox = new ComboBox
                {
                    
                    ItemsSource = new List<string> { "=", "≤", "≥" },
                    SelectedItem = SavedElements.arraySign[i],
                    BorderThickness = new Thickness(1),
                    BorderBrush = System.Windows.Media.Brushes.Black,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Margin = new Thickness(0)
                };

                Grid.SetRow(signComboBox, i + 1);
                Grid.SetColumn(signComboBox, columns + additionalVariables.GetLength(1) + 1);
                textBoxContainer.Children.Add(signComboBox);

                TextBox valueTextBox = new TextBox
                {
                    IsReadOnly = true,
                    BorderThickness = new Thickness(1),
                    BorderBrush = Brushes.Black,
                    Padding = new Thickness(5),
                    Text = SavedElements.arrayResult[i].ToString()
                };

                Grid.SetRow(valueTextBox, i + 1);
                Grid.SetColumn(valueTextBox, columns + additionalVariables.GetLength(1) + 2);
                textBoxContainer.Children.Add(valueTextBox);
            }
        }

        private bool ValidateTextBoxInput(TextBox textBox)
        {

            // Проверка, что введённое значение -1, 0 или 1
            if (int.TryParse(textBox.Text, out int value) && (value == -1 || value == 0 || value == 1))
            {
                textBox.Background = System.Windows.Media.Brushes.White;
                return true;
            }
            else
            {
                textBox.Background = System.Windows.Media.Brushes.LightPink;
                return false;
            }
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
        private bool ValidateAllUTextBoxes()
        {
            
            bool hasErrors = false;

            foreach (var child in textBoxContainer.Children)
            {
               
                if (child is TextBox textBox && !textBox.IsReadOnly)
                {
                    if (!ValidateTextBoxInput(textBox))
                    {
                        hasErrors = true;
                    }
                    if (!int.TryParse(textBox.Text, out _))
                    {
                        hasErrors = true;
                        textBox.Background = Brushes.LightPink;
                    }
                    else
                    {
                        textBox.Background = Brushes.White;
                    }
                }
            }

            if (hasErrors)
            {
                MessageBox.Show("Некоторые значения в полях U неверны. Пожалуйста, исправьте их перед продолжением.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return hasErrors;
        }


        private void AddNewVariableU()
        {
            // Сбрасываем счётчик index при каждом новом создании переменных
            if (additionalVariables.GetLength(1) == 0)
            {
                index = 1;
            }
            else
            {
                index++;
            }

            // Перевірка, чи кількість змінних U не перевищує кількість рядків
            if (additionalVariables.GetLength(1) >= rows)
            {
                MessageBox.Show("Максимальна кількість додаткових змінних U досягнута.", "Додавання змінних", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Створюємо новий масив з додатковим стовпцем
            int newColumns = additionalVariables.GetLength(1) + 1;

            double[,] newAdditionalVariables = new double[rows, newColumns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < additionalVariables.GetLength(1); j++)
                {
                    newAdditionalVariables[i, j] = additionalVariables[i, j];
                }
                newAdditionalVariables[i, newColumns - 1] = 0;
            }

            additionalVariables = newAdditionalVariables;
            CreateTextBox();
        }



        public static double[,] Concat2DArrays(double[,] array1, double[,] array2)
        {
            int rows1 = array1.GetLength(0);
            int cols1 = array1.GetLength(1);

            int rows2 = array2.GetLength(0);
            int cols2 = array2.GetLength(1);

            //if (cols1 != cols2)
            //{
            //    throw new ArgumentException("Both arrays must have the same number of columns to concatenate.");
            //}

            // Создаём результирующий массив с корректными размерами
            double[,] result = new double[rows1, cols1+cols2];

            // Копируем первый массив
            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols1; j++)
                {
                    result[i, j] = array1[i, j];
                }
            }

            Console.WriteLine("1");

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    Console.Write(result[i, j] + " ");
                }
                Console.WriteLine();
            }

            // Копируем второй массив
            for (int i = 0; i < rows2; i++)
            {
                for (int j = 0; j < cols2; j++)
                {
                    result[ i, cols1+ j] = array2[i, j];
                }
            }

            Console.WriteLine("2");

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    Console.Write(result[i, j] + " ");
                }
                Console.WriteLine();
            }

            return result;
        }

        private void RemoveVariableU()
        {
            if (additionalVariables.GetLength(1) == 0)
            {
                MessageBox.Show("Немає змінних щоб їх видалити.", "Видалення змінних", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Уменьшаем количество столбцов в массиве
            int newColumns = additionalVariables.GetLength(1) - 1;
            double[,] newAdditionalVariables = new double[rows, newColumns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < newColumns; j++)
                {
                    newAdditionalVariables[i, j] = additionalVariables[i, j];
                }
            }

            additionalVariables = newAdditionalVariables;

            // Обновляем индекс
            index--;

            // Пересоздаем таблицу
            CreateTextBox();
        }




        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {

            AddNewVariableU();
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            RemoveVariableU();
        }




        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            CreateNewElements createNewElements = new CreateNewElements();

            SetRows(rows);
            SetColumns(columns);

            createNewElements.GetRows(strRows);
            createNewElements.GetColumns(strColumns);
            createNewElements.CreateTextBox();
            createNewElements.Zfunc();
            createNewElements.Show();
            this.Hide();
        }

        private void Button_Click_Next(object sender, RoutedEventArgs e)
        {
            if (ValidateAllUTextBoxes())
            {
                return; // Если есть ошибки, прерываем выполнение
            }

            SavedElements.fullArray = Concat2DArrays(SavedElements.array, SavedElements.additionalVariables);

            DeltaSearch deltaSearch = new DeltaSearch();


            deltaSearch.CreateTextBox();

            deltaSearch.Show();

            this.Hide();
        }
    }
}
