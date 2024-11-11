using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
        }

        public TextBox deltaTextBox;

        public TextBox deltaValueTextBox;

        SavedElements savedElements = new SavedElements();

        public int rows = SavedElements.SetRowsFullArray();

        public int columns = SavedElements.SetColumnsFullArray();

        public int rowsX = SavedElements.SetRowsX();

        public int columnsX = SavedElements.SetColumnsX();

        public int rowsU = SavedElements.SetRowsU();

        public int columnsU = SavedElements.SetColumnsU();

        public void CreateTextBox()
        {
            textBoxContainer.Children.Clear();
            textBoxContainer.RowDefinitions.Clear();
            textBoxContainer.ColumnDefinitions.Clear();

            textBoxContainer.ShowGridLines = true;

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
                    Background = System.Windows.Media.Brushes.LightPink,
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
                    Background = System.Windows.Media.Brushes.LightPink,
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
                Background = System.Windows.Media.Brushes.LightPink,
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
                    Background = System.Windows.Media.Brushes.LightPink,
                    Padding = new Thickness(5)
                };

                rowLabel.Click += Button_Click_Header;

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
                Background = System.Windows.Media.Brushes.LightPink,
                Padding = new Thickness(5)
            };

            Grid.SetRow(deltaLabel, rows + 1);
            Grid.SetColumn(deltaLabel, 0);
            textBoxContainer.Children.Add(deltaLabel);

            for (int j = 0; j < columnsX + columnsU; j++)
            {
                deltaTextBox = new TextBox
                {
                    IsReadOnly = true,
                    BorderThickness = new Thickness(1),
                    BorderBrush = System.Windows.Media.Brushes.Black,
                    Padding = new Thickness(5)
                };

                Grid.SetRow(deltaTextBox, rows + 1);
                Grid.SetColumn(deltaTextBox, j + 1);
                textBoxContainer.Children.Add(deltaTextBox);
            }

            deltaValueTextBox = new TextBox
            {
                IsReadOnly = true,
                BorderThickness = new Thickness(1),
                BorderBrush = System.Windows.Media.Brushes.Black,
                Padding = new Thickness(5)
            };

            Grid.SetRow(deltaValueTextBox, rows + 1);
            Grid.SetColumn(deltaValueTextBox, columnsX + columnsU + 1);
            textBoxContainer.Children.Add(deltaValueTextBox);
        }


      



        // Обработчик нажатия кнопки
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Button button = sender as Button;

            if (button.Tag != null)
            {
                Console.WriteLine(button.Tag); // Вывод в консоль значения Tag
            }
            else
            {
                Console.WriteLine("Tag не задан для этой кнопки.");
            }

            if (button.Background == Brushes.White)
            {
                button.Background = Brushes.LightBlue; // при нажатии меняем на голубой цвет

            }
            else
            {
                button.Background = Brushes.White; // если уже голубой, возвращаем белый
            }
        }


        private void Button_Click_Header(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button.Tag != null)
            {
                Console.WriteLine(button.Tag); // Вывод в консоль значения Tag
            }
            else
            {
                Console.WriteLine("Tag не задан для этой кнопки.");
            }

            if (button.Background == Brushes.LightPink)
            {
                button.Background = Brushes.LightBlue; // при нажатии меняем на голубой цвет
            }
            else
            {
                button.Background = Brushes.LightPink; // если уже голубой, возвращаем белый
            }
        }

        public static double CalculateFormula(double row1, double textBox1, double row2, double textBox2, double column)
        {
            double result = (row1 * textBox1 + row2 * textBox2) - column;
            Console.WriteLine($"Результат формулы: {result}");
            return result;
        }

        public static double CalculateFormulaLast(double row1, double textBox1, double row2, double textBox2)
        {
            double result = (row1 * textBox1 + row2 * textBox2);
            Console.WriteLine($"Результат формулы: {result}");
            return result;
        }

        private void Button_Click_Result(object sender, RoutedEventArgs e)
        {
            foreach (UIElement element in textBoxContainer.Children)
            {
                if (element is Button button)
                {
                    if (button.Background == Brushes.LightBlue)
                    {
                        if (button.Content.ToString().StartsWith("U"))
                        {
                            Console.WriteLine("Button_Click_Result");
                            double row1 = double.Parse(button.Tag?.ToString() ?? "0");
                            Console.WriteLine(row1);
                            double textBox1 = double.Parse(button.Tag?.ToString() ?? "0");
                            Console.WriteLine(textBox1);
                            double row2 = double.Parse(button.Tag?.ToString() ?? "0");
                            Console.WriteLine(row2);
                            double textBox2 = double.Parse(button.Tag?.ToString() ?? "0");
                            Console.WriteLine(textBox2);

                            double result2 = CalculateFormulaLast(row1, textBox1, row2, textBox2);

                            // Use deltaValueTextBox to display the result
                            deltaValueTextBox.Text = result2.ToString();

                            button.Background = Brushes.LightPink;

                        }
                        else
                        {
                            button.Background = Brushes.White;
                        }
                    }
                }
            }
        }




        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {


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

        }
    }
}
