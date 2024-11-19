using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static System.Net.Mime.MediaTypeNames;

namespace OperationsResearch.Dual
{
    /// <summary>
    /// Логика взаимодействия для DeltaSearch.xaml
    /// </summary>
    public partial class DeltaSearch : Window
    {
        public DeltaSearch()
        {
            InitializeComponent();
            InitializeArrayDelta();
        }


        public TextBox deltaTextBox;

        public TextBox deltaValueTextBox;

        public int result = 0;

        public static int[] arrayDelta;


        SavedElements savedElements = new SavedElements();

        public int rows = SavedElements.SetRowsFullArray();

        public int columns = SavedElements.SetColumnsFullArray();

        public int rowsX = SavedElements.SetRowsX();

        public int columnsX = SavedElements.SetColumnsX();

        public int rowsU = SavedElements.SetRowsU();

        public int columnsU = SavedElements.SetColumnsU();

        private void InitializeArrayDelta()
        {
            savedElements.InitializeArrayDelta(columnsX, columnsU);
        }

        public void CreateTextBox()
        {
            textBoxContainer.Children.Clear();
            textBoxContainer.RowDefinitions.Clear();
            textBoxContainer.ColumnDefinitions.Clear();

            textBoxContainer.ShowGridLines = false;

            // Создаем строку для заголовков столбцов (X1, X2 и т.д.)
            textBoxContainer.RowDefinitions.Add(new RowDefinition());
            textBoxContainer.ColumnDefinitions.Add(new ColumnDefinition()); // Пустая ячейка для номера строки

            // Добавляем заголовки для столбцов X1, X2, ...
            for (int j = 0; j < columnsX; j++)
            {
                textBoxContainer.ColumnDefinitions.Add(new ColumnDefinition());

                Button headerLabelX = new Button
                {
                    Content = $"X{j + 1}",
                    Tag = SavedElements.arrayZ[j].ToString(), // Сохраняем значение из массива в свойство Tag                                                       
                    VerticalAlignment = VerticalAlignment.Center,
                    BorderThickness = new Thickness(1),
                    BorderBrush = System.Windows.Media.Brushes.Black,
                    Background = System.Windows.Media.Brushes.SkyBlue,
                    Padding = new Thickness(5)
                };

                headerLabelX.Click += Button_Click_Header;


                Grid.SetRow(headerLabelX, 0);
                Grid.SetColumn(headerLabelX, j + 1);
                textBoxContainer.Children.Add(headerLabelX);
            }

            // Добавляем заголовки для столбцов U1, U2, ...
            for (int j = 0; j < columnsU; j++)
            {
                textBoxContainer.ColumnDefinitions.Add(new ColumnDefinition());

                Button headerLabelU = new Button
                {
                    Content = $"U{j + 1}",
                    Tag = 0,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    BorderThickness = new Thickness(1),
                    BorderBrush = System.Windows.Media.Brushes.Black,
                    Background = System.Windows.Media.Brushes.SkyBlue,
                    Padding = new Thickness(5)
                };

                headerLabelU.Click += Button_Click_Header;

                Grid.SetRow(headerLabelU, 0);
                Grid.SetColumn(headerLabelU, columnsX + j + 1);
                textBoxContainer.Children.Add(headerLabelU);
            }

            // Добавляем заголовок "Значення" в конец
            textBoxContainer.ColumnDefinitions.Add(new ColumnDefinition());

            Label valueHeader = new Label
            {
                Content = "Значення",
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                BorderThickness = new Thickness(1),
                BorderBrush = System.Windows.Media.Brushes.Black,
                Background = System.Windows.Media.Brushes.SkyBlue,
                Padding = new Thickness(5)
            };

            Grid.SetRow(valueHeader, 0);
            Grid.SetColumn(valueHeader, columnsX + columnsU + 1);
            textBoxContainer.Children.Add(valueHeader);

            // Добавляем строки с номерами и кнопками вместо текстовых полей
            for (int i = 0; i < rows; i++)
            {
                textBoxContainer.RowDefinitions.Add(new RowDefinition());

                Button rowLabel = new Button
                {
                    Content = $"U{i + 1}",
                    Tag = 0,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    BorderThickness = new Thickness(1),
                    BorderBrush = System.Windows.Media.Brushes.Black,
                    Background = System.Windows.Media.Brushes.SkyBlue,
                    Padding = new Thickness(5)
                };

                rowLabel.Click += Button_Click_Side;


                Grid.SetRow(rowLabel, i + 1);
                Grid.SetColumn(rowLabel, 0);
                textBoxContainer.Children.Add(rowLabel);

                // Создаем кнопки для каждой строки
                for (int j = 0; j < columnsX + columnsU; j++)
                {
                    Button button = new Button
                    {
                        Content = (j < columnsX) ? SavedElements.array[i, j].ToString() : SavedElements.additionalVariables[i, j - columnsX].ToString(),
                        Tag = (j < columnsX) ? SavedElements.array[i, j].ToString() : SavedElements.additionalVariables[i, j - columnsX].ToString(),
                        Background = Brushes.White,
                        BorderThickness = new Thickness(1),
                        BorderBrush = System.Windows.Media.Brushes.Black,
                        Padding = new Thickness(5)
                    };

                    button.Click += Button_Click; // добавляем обработчик нажатия кнопки

                    Grid.SetRow(button, i + 1);
                    Grid.SetColumn(button, j + 1);
                    textBoxContainer.Children.Add(button);
                }

                // Кнопка для "Значення"
                Button valueButton = new Button
                {
                    Content = SavedElements.arrayResult[i].ToString(),
                    Tag = SavedElements.arrayResult[i].ToString(),
                    Background = Brushes.White,
                    BorderThickness = new Thickness(1),
                    BorderBrush = System.Windows.Media.Brushes.Black,
                    Padding = new Thickness(5)
                };

                valueButton.Click += Button_Click;

                Grid.SetRow(valueButton, i + 1);
                Grid.SetColumn(valueButton, columnsX + columnsU + 1);
                textBoxContainer.Children.Add(valueButton);
            }

            // Добавляем строку Delta
            textBoxContainer.RowDefinitions.Add(new RowDefinition());

            Label deltaLabel = new Label
            {
                Content = "Delta",
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                BorderThickness = new Thickness(1),
                BorderBrush = System.Windows.Media.Brushes.Black,
                Background = System.Windows.Media.Brushes.SkyBlue,
                Padding = new Thickness(5)
            };

            Grid.SetRow(deltaLabel, rows + 1);
            Grid.SetColumn(deltaLabel, 0);
            textBoxContainer.Children.Add(deltaLabel);
            
            for (int j = 0; j < columnsX + columnsU + 1; j++)
            {
                
                deltaTextBox = new TextBox
                {
                    IsReadOnly = true,
                    BorderThickness = new Thickness(1),
                    BorderBrush = System.Windows.Media.Brushes.Black,
                    Padding = new Thickness(5),
                   
                };
                

                Grid.SetRow(deltaTextBox, rows + 1);
                Grid.SetColumn(deltaTextBox, j + 1);
                textBoxContainer.Children.Add(deltaTextBox);
            }
        }


        // Обработчик нажатия кнопки
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button.Tag != null && int.TryParse(button.Tag.ToString(), out int tagValue))
            {
                Console.WriteLine(tagValue); // Вывод в консоль значения Tag

                if (button.Background == Brushes.White)
                {
                    result *= tagValue;   /// числа
                    Console.WriteLine("Operation: " + result);
                    button.Background = Brushes.LightGreen; // при нажатии меняем на голубой цвет
                }
                else
                {
                    button.Background = Brushes.White; // если уже голубой, возвращаем белый
                }
            }
            else
            {
                Console.WriteLine("Tag не задан или не может быть преобразован в double для этой кнопки.");
            }
        }

        private void Button_Click_Header(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button.Tag != null && int.TryParse(button.Tag.ToString(), out int tagValue))
            {
                Console.WriteLine(tagValue); // Вывод в консоль значения Tag

                if (button.Background == Brushes.SkyBlue)
                {
                    result -= tagValue; /// голова -> x1 x2 u1 u2
                    Console.WriteLine("Operation: " + result);

                    button.Background = Brushes.LightGreen; // при нажатии меняем на голубой цвет
                }
                else
                {
                    button.Background = Brushes.SkyBlue; // если уже голубой, возвращаем белый
                }
            }
            else
            {
                Console.WriteLine("Tag не задан или не может быть преобразован в double для этой кнопки.");
            }
        }

        private void Button_Click_Side(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button.Tag != null && int.TryParse(button.Tag.ToString(), out int tagValue))
            {
                Console.WriteLine(tagValue); // Вывод в консоль значения Tag

                if (button.Background == Brushes.SkyBlue)
                {


                    result += tagValue;   /// бок/слева ->  u1 u2
                    Console.WriteLine("Operation: " + result);

                    button.Background = Brushes.LightGreen; // при нажатии меняем на голубой цвет
                }
                else
                {
                    button.Background = Brushes.SkyBlue; // если уже голубой, возвращаем белый
                }
            }
            else
            {
                Console.WriteLine("Tag не задан или не может быть преобразован в double для этой кнопки.");
            }
        }

        private void WriteResultToColumn(int rowIndex, int columnIndex, int value)
        {
            foreach (UIElement child in textBoxContainer.Children)
            {
                if (Grid.GetRow(child) == rowIndex + 1 && Grid.GetColumn(child) == columnIndex && child is TextBox textBox)
                {
                    textBox.Text = value.ToString();
                    return;
                }
            }
        }


        public int indexDelta = 1;
        public int countDelta = 1;

        private void Button_Click_Result(object sender, RoutedEventArgs e)
        {
            // Проверяем, превышает ли количество вычислений число доступных колонок Delta
            if (countDelta > columnsX + columnsU+1) // Проверяем количество доступных колонок
            {
                MessageBox.Show("Помилка: кількість обчислень перевищує число доступних стовпців.", "Помилка обчислень", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            foreach (UIElement element in textBoxContainer.Children)
            {
                if (element is Button button)
                {
                    if (button.Background == Brushes.LightGreen)
                    {
                        if (button.Content.ToString().StartsWith("X") || button.Content.ToString().StartsWith("U"))
                        {
                            // Сохраняем результат в массив
                            SavedElements.arrayDelta[countDelta - 1] = result;

                            // Используем метод для записи результата в текущую колонку Delta
                            WriteResultToColumn(rows, countDelta, SavedElements.arrayDelta[countDelta - 1]);

                            button.Background = Brushes.SkyBlue;
                        }
                        else
                        {
                            button.Background = Brushes.White;
                        }
                    }
                }
            }

            countDelta++; // Увеличиваем индекс для следующей колонки
            result = 0;   // Сбрасываем результат
        }



        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {

            AddNewElements addNewElements = new AddNewElements();


            addNewElements.GetRows(rowsX);
            addNewElements.GetColumns(columnsX);
            addNewElements.CreateTextBox();
            addNewElements.Zfunc();
            addNewElements.Show();
            this.Hide();
        }

        private void Button_Click_Next(object sender, RoutedEventArgs e)
        {
            SavedElements.ShowValues();
            SavedElements.ShowValuesRezult();
            SavedElements.ShowValuesZ();
            SavedElements.ShowValuesSign();
            SavedElements.ShowExtremum();
            SavedElements.ShowadditionalVariables();
            SavedElements.ShowFullArray();
            SavedElements.ShowValuesDleta();

            WorkWithSupportElement workWithSupportElement = new WorkWithSupportElement();

            workWithSupportElement.CreateTextBox();

            workWithSupportElement.Show();

            this.Close();
        }
    }
}
