using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace OperationsResearch.Dual
{
    /// <summary>
    /// Логика взаимодействия для WorkWithSupportElement.xaml
    /// </summary>
    public partial class WorkWithSupportElement : Window
    {
        public WorkWithSupportElement()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidateTextBox(textBox1);
        }

        // Метод для обработки изменения текста в textBox2
        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidateTextBox(textBox2);
        }



        public static int supportElementRow = 0;
        public static int supportElementColumn = 0;

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

            textBoxContainer.ShowGridLines = false;

            // Создаем строку для заголовков столбцов (X1, X2 и т.д.)
            textBoxContainer.RowDefinitions.Add(new RowDefinition());
            textBoxContainer.ColumnDefinitions.Add(new ColumnDefinition()); // Пустая ячейка для номера строки

            // Добавляем заголовки для столбцов X1, X2, ...
            for (int j = 0; j < columnsX; j++)
            {
                textBoxContainer.ColumnDefinitions.Add(new ColumnDefinition());

                Label headerLabelX = new Label
                {
                    Content = $"X{j + 1}",
                    VerticalAlignment = VerticalAlignment.Center,
                    BorderThickness = new Thickness(1),
                    BorderBrush = System.Windows.Media.Brushes.Black,
                    Background = System.Windows.Media.Brushes.SkyBlue,
                    Padding = new Thickness(5)
                };

                //headerLabelX.Click += Button_Click_Header;


                Grid.SetRow(headerLabelX, 0);
                Grid.SetColumn(headerLabelX, j + 1);
                textBoxContainer.Children.Add(headerLabelX);
            }

            // Добавляем заголовки для столбцов U1, U2, ...
            for (int j = 0; j < columnsU; j++)
            {
                textBoxContainer.ColumnDefinitions.Add(new ColumnDefinition());

                Label headerLabelU = new Label
                {

                    Content = $"U{j + 1}",
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    BorderThickness = new Thickness(1),
                    BorderBrush = System.Windows.Media.Brushes.Black,
                    Background = System.Windows.Media.Brushes.SkyBlue,
                    Padding = new Thickness(5)
                };

                //headerLabelU.Click += Button_Click_Header;

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

                Label rowLabel = new Label
                {
                    Content = $"U{i + 1}",
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    BorderThickness = new Thickness(1),
                    BorderBrush = System.Windows.Media.Brushes.Black,
                    Background = System.Windows.Media.Brushes.SkyBlue,
                    Padding = new Thickness(5)
                };



                Grid.SetRow(rowLabel, i + 1);
                Grid.SetColumn(rowLabel, 0);
                textBoxContainer.Children.Add(rowLabel);

                // Создаем кнопки для каждой строки
                for (int j = 0; j < columnsX + columnsU; j++)
                {
                    TextBox textBox = new TextBox
                    {
                        IsReadOnly = true,
                        Text = (j < columnsX) ? SavedElements.array[i, j].ToString() : SavedElements.additionalVariables[i, j - columnsX].ToString(),
                        Tag = (j < columnsX) ? SavedElements.array[i, j].ToString() : SavedElements.additionalVariables[i, j - columnsX].ToString(),
                        Background = Brushes.White,
                        BorderThickness = new Thickness(1),
                        BorderBrush = System.Windows.Media.Brushes.Black,
                        Padding = new Thickness(5)
                    };


                    Grid.SetRow(textBox, i + 1);
                    Grid.SetColumn(textBox, j + 1);
                    textBoxContainer.Children.Add(textBox);
                }

                // Кнопка для "Значення"
                TextBox valueTextBox = new TextBox
                {
                    IsReadOnly = true,
                    Text = SavedElements.arrayResult[i].ToString(),
                    Background = Brushes.White,
                    BorderThickness = new Thickness(1),
                    BorderBrush = System.Windows.Media.Brushes.Black,
                    Padding = new Thickness(5)
                };

                //valueButton.Click += Button_Click;

                Grid.SetRow(valueTextBox, i + 1);
                Grid.SetColumn(valueTextBox, columnsX + columnsU + 1);
                textBoxContainer.Children.Add(valueTextBox);
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

                TextBox deltaTextBox = new TextBox
                {
                    IsReadOnly = true,
                    Text = SavedElements.arrayDelta[j].ToString(),
                    Tag = SavedElements.arrayDelta[j].ToString(),
                    Background = Brushes.White,
                    BorderThickness = new Thickness(1),
                    BorderBrush = System.Windows.Media.Brushes.Black,
                    Padding = new Thickness(5)

                };


                Grid.SetRow(deltaTextBox, rows + 1);
                Grid.SetColumn(deltaTextBox, j + 1);
                textBoxContainer.Children.Add(deltaTextBox);
            }
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

        private TextBox _previousTextBox; // Поле для хранения ранее выбранного TextBox

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            // Проверяем корректность значений в текстовых полях
            if (!ValidateTextBox(textBox1) || !ValidateTextBox(textBox2))
            {
                MessageBox.Show("Будь ласка, виправте всі помилки вводу перед переходом.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            supportElementRow = int.Parse(textBox1.Text) - 1;
            supportElementColumn = int.Parse(textBox2.Text) - 1;

            SavedElements.supportElementRow = supportElementRow;
            SavedElements.supportElementColumn = supportElementColumn;

            if (supportElementRow < 0 || supportElementRow >= rows || supportElementColumn < 0 || supportElementColumn >= (columnsX + columnsU))
            {
                MessageBox.Show("Ви вийшли за грані таблички", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            TextBox selectedTextBox = null;

            foreach (UIElement element in textBoxContainer.Children)
            {
                if (Grid.GetRow(element) == supportElementRow + 1 && Grid.GetColumn(element) == supportElementColumn + 1)
                {
                    if (element is TextBox textBox)
                    {
                        selectedTextBox = textBox;
                        SavedElements.supportElement = int.Parse(selectedTextBox.Text);
                        break;
                    }
                }
            }

            if (selectedTextBox != null)
            {
                // Возвращаем предыдущий TextBox в исходный цвет
                if (_previousTextBox != null && _previousTextBox != selectedTextBox)
                {
                    _previousTextBox.Background = Brushes.White;
                }

                // Устанавливаем новый цвет для выбранного TextBox
                selectedTextBox.Background = Brushes.MediumPurple;

                // Сохраняем текущий TextBox как предыдущий
                _previousTextBox = selectedTextBox;
            }
        }



        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            DeltaSearch deltaSearch = new DeltaSearch();

            deltaSearch.CreateTextBox();


            deltaSearch.Show();

            this.Close();

        }

        private void Button_Click_Next(object sender, RoutedEventArgs e)
        {
            //SavedElements.ShowValues();
            //SavedElements.ShowValuesRezult();
            //SavedElements.ShowValuesZ();
            //SavedElements.ShowValuesSign();
            //SavedElements.ShowExtremum();
            //SavedElements.ShowadditionalVariables();
            //SavedElements.ShowFullArray();
            //SavedElements.ShowValuesDleta();

            SavedElements.ShowSupportElement();
            SavedElements.ShowSupportElementRowAndColumn();

            WorkWithTablet workWithTablet = new WorkWithTablet();

            workWithTablet.CreateTextBox();
            workWithTablet.CreateTextBoxResult();

            workWithTablet.Show();

            this.Close();
        }

        private void Button_Click_The_End(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
