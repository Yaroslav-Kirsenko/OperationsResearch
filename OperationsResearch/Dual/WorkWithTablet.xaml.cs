using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace OperationsResearch.Dual
{
    /// <summary>
    /// Логика взаимодействия для WorkWithTablet.xaml
    /// </summary>
    public partial class WorkWithTablet : Window
    {
        public WorkWithTablet()
        {
            InitializeComponent();
            MyButton.Content = "/ " + SavedElements.ToFraction(SavedElements.supportElement); // MyButton — имя кнопки
        }


        SavedElements savedElements = new SavedElements();

        public int rows = SavedElements.SetRowsFullArray();

        public int columns = SavedElements.SetColumnsFullArray();

        public int rowsX = SavedElements.SetRowsX();

        public int columnsX = SavedElements.SetColumnsX();

        public int rowsU = SavedElements.SetRowsU();

        public int columnsU = SavedElements.SetColumnsU();

        TextBox textBoxResult;
        TextBox valueTextBoxResult;


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

                //headerLabelX.Click += Button_Click_Header;


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
                    Tag = 0,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    BorderThickness = new Thickness(1),
                    BorderBrush = System.Windows.Media.Brushes.Black,
                    Background = System.Windows.Media.Brushes.SkyBlue,
                    Padding = new Thickness(5)
                };

                //rowLabel.Click += Button_Click_Side;


                Grid.SetRow(rowLabel, i + 1);
                Grid.SetColumn(rowLabel, 0);
                textBoxContainer.Children.Add(rowLabel);

                // Создаем кнопки для каждой строки
                for (int j = 0; j < columns; j++)
                {
                    Button button = new Button
                    {

                        Content = SavedElements.ToFraction(SavedElements.fullArray[i, j]),
                        Tag = SavedElements.fullArray[i, j].ToString(),
                        //Content = (j < columnsX) ? SavedElements.array[i, j].ToString() : SavedElements.additionalVariables[i, j - columnsX].ToString(),
                        //Tag = (j < columnsX) ? SavedElements.array[i, j].ToString() : SavedElements.additionalVariables[i, j - columnsX].ToString(),
                        Background = Brushes.White,
                        BorderThickness = new Thickness(1),
                        BorderBrush = System.Windows.Media.Brushes.Black,
                        Padding = new Thickness(5)
                    };

                    if (SavedElements.supportElementRow == i && SavedElements.supportElementColumn == j)
                    {
                        button.Background = Brushes.MediumPurple;
                    }

                    //button.Click += Button_Click; // добавляем обработчик нажатия кнопки

                    Grid.SetRow(button, i + 1);
                    Grid.SetColumn(button, j + 1);
                    textBoxContainer.Children.Add(button);
                }

                // Кнопка для "Значення"
                Button valueButton = new Button
                {
                    Content = SavedElements.ToFraction(SavedElements.arrayResult[i]),
                    Tag = SavedElements.arrayResult[i].ToString(),
                    Background = Brushes.White,
                    BorderThickness = new Thickness(1),
                    BorderBrush = System.Windows.Media.Brushes.Black,
                    Padding = new Thickness(5)
                };

                //valueButton.Click += Button_Click;

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

                Button deltaTextBox = new Button
                {
                    Content = SavedElements.arrayDelta[j].ToString(),
                    Tag = SavedElements.arrayDelta[j].ToString(),
                    BorderThickness = new Thickness(1),
                    Background = Brushes.White,
                    BorderBrush = System.Windows.Media.Brushes.Black,
                    Padding = new Thickness(5),

                };


                Grid.SetRow(deltaTextBox, rows + 1);
                Grid.SetColumn(deltaTextBox, j + 1);
                textBoxContainer.Children.Add(deltaTextBox);
            }
        }




        public void CreateTextBoxResult()
        {
            textBoxContainerResult.Children.Clear();
            textBoxContainerResult.RowDefinitions.Clear();
            textBoxContainerResult.ColumnDefinitions.Clear();

            textBoxContainerResult.ShowGridLines = false;

            // Создаем строку для заголовков столбцов (X1, X2 и т.д.)
            textBoxContainerResult.RowDefinitions.Add(new RowDefinition());
            textBoxContainerResult.ColumnDefinitions.Add(new ColumnDefinition()); // Пустая ячейка для номера строки

            // Добавляем заголовки для столбцов X1, X2, ...
            for (int j = 0; j < columnsX; j++)
            {
                textBoxContainerResult.ColumnDefinitions.Add(new ColumnDefinition());

                Label headerLabelXResult = new Label
                {
                    Content = $"X{j + 1}",
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    BorderThickness = new Thickness(1),
                    BorderBrush = System.Windows.Media.Brushes.Black,
                    Background = System.Windows.Media.Brushes.SkyBlue,
                    Padding = new Thickness(5)
                };



                Grid.SetRow(headerLabelXResult, 0);
                Grid.SetColumn(headerLabelXResult, j + 1);
                textBoxContainerResult.Children.Add(headerLabelXResult);
            }

            // Добавляем заголовки для столбцов U1, U2, ...
            for (int j = 0; j < columnsU; j++)
            {
                textBoxContainerResult.ColumnDefinitions.Add(new ColumnDefinition());

                Label headerLabelUResult = new Label
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

                Grid.SetRow(headerLabelUResult, 0);
                Grid.SetColumn(headerLabelUResult, columnsX + j + 1);
                textBoxContainerResult.Children.Add(headerLabelUResult);
            }

            // Добавляем заголовок "Значення" в конец
            textBoxContainerResult.ColumnDefinitions.Add(new ColumnDefinition());

            Label valueHeaderResult = new Label
            {
                Content = "Значення",
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                BorderThickness = new Thickness(1),
                BorderBrush = System.Windows.Media.Brushes.Black,
                Background = System.Windows.Media.Brushes.SkyBlue,
                Padding = new Thickness(5)
            };

            Grid.SetRow(valueHeaderResult, 0);
            Grid.SetColumn(valueHeaderResult, columnsX + columnsU + 1);
            textBoxContainerResult.Children.Add(valueHeaderResult);

            // Добавляем строки с номерами и кнопками вместо текстовых полей
            for (int i = 0; i < rows; i++)
            {
                textBoxContainerResult.RowDefinitions.Add(new RowDefinition());

                Label rowLabelResult = new Label
                {
                    Content = $"U{i + 1}",
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    BorderThickness = new Thickness(1),
                    BorderBrush = System.Windows.Media.Brushes.Black,
                    Background = System.Windows.Media.Brushes.SkyBlue,
                    Padding = new Thickness(5)
                };



                Grid.SetRow(rowLabelResult, i + 1);
                Grid.SetColumn(rowLabelResult, 0);
                textBoxContainerResult.Children.Add(rowLabelResult);

                // Создаем кнопки для каждой строки
                for (int j = 0; j < columns; j++)
                {
                    textBoxResult = new TextBox
                    {
                        IsReadOnly = true,
                        //Text = (j < columnsX) ? SavedElements.array[i, j].ToString() : SavedElements.additionalVariables[i, j - columnsX].ToString(),
                        //Tag = (j < columnsX) ? SavedElements.array[i, j].ToString() : SavedElements.additionalVariables[i, j - columnsX].ToString(),
                        Background = Brushes.White,
                        BorderThickness = new Thickness(1),
                        BorderBrush = System.Windows.Media.Brushes.Black,
                        Padding = new Thickness(5)
                    };


                    Grid.SetRow(textBoxResult, i + 1);
                    Grid.SetColumn(textBoxResult, j + 1);
                    textBoxContainerResult.Children.Add(textBoxResult);
                }

                // Кнопка для "Значення"
                TextBox valueTextBoxResult = new TextBox
                {
                    IsReadOnly = true,
                    //Text = SavedElements.arrayResult[i].ToString(),
                    Background = Brushes.White,
                    BorderThickness = new Thickness(1),
                    BorderBrush = System.Windows.Media.Brushes.Black,
                    Padding = new Thickness(5)
                };

                //valueButton.Click += Button_Click;

                Grid.SetRow(valueTextBoxResult, i + 1);
                Grid.SetColumn(valueTextBoxResult, columnsX + columnsU + 1);
                textBoxContainerResult.Children.Add(valueTextBoxResult);
            }

            // Добавляем строку Delta
            textBoxContainerResult.RowDefinitions.Add(new RowDefinition());

            Label deltaLabelResult = new Label
            {
                Content = "Delta",
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                BorderThickness = new Thickness(1),
                BorderBrush = System.Windows.Media.Brushes.Black,
                Background = System.Windows.Media.Brushes.SkyBlue,
                Padding = new Thickness(5)
            };

            Grid.SetRow(deltaLabelResult, rows + 1);
            Grid.SetColumn(deltaLabelResult, 0);
            textBoxContainerResult.Children.Add(deltaLabelResult);

            for (int j = 0; j < columnsX + columnsU + 1; j++)
            {

                TextBox deltaTextBoxResult = new TextBox
                {
                    IsReadOnly = true,
                    //Text = SavedElements.arrayDelta[j].ToString(),
                    //Tag = SavedElements.arrayDelta[j].ToString(),
                    Background = Brushes.White,
                    BorderThickness = new Thickness(1),
                    BorderBrush = System.Windows.Media.Brushes.Black,
                    Padding = new Thickness(5)

                };


                Grid.SetRow(deltaTextBoxResult, rows + 1);
                Grid.SetColumn(deltaTextBoxResult, j + 1);
                textBoxContainerResult.Children.Add(deltaTextBoxResult);
            }
        }


        private void Button_Click_SupportElement(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                // Индексы строки и столбца, где находится supportElement
                int rowIndex = SavedElements.supportElementRow;
                int columnIndex = SavedElements.supportElementColumn;

                // Получаем значение supportElement
                double supportElementValue = SavedElements.supportElement;

                // Проверяем, чтобы деление на 0 не происходило
                if (supportElementValue == 0)
                {
                    MessageBox.Show("Support element value cannot be zero!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Делим каждый элемент строки на supportElement
                for (int j = 0; j < SavedElements.fullArray.GetLength(1); j++)
                {

                    SavedElements.fullArray[rowIndex, j] /= supportElementValue;
                    //if (j < columnsX)
                    //{

                    //    SavedElements.array[rowIndex, j] /= supportElementValue;
                    //    //SavedElements.arrayResult[rowIndex] /= supportElementValue;
                    //}
                    //else
                    //{
                    //    SavedElements.additionalVariables[rowIndex, j - columnsX] /= supportElementValue;
                    //}
                }

                SavedElements.arrayResult[rowIndex] /= supportElementValue;


                // Добавляем строки с номерами и кнопками вместо текстовых полей

                for (int j = 0; j < columns; j++)
                {
                    textBoxResult = new TextBox
                    {
                        IsReadOnly = true,
                        Text = SavedElements.ToFraction(SavedElements.fullArray[rowIndex, j]),
                        //Text = SavedElements.fullArray[rowIndex, j].ToString(),
                        Tag = SavedElements.fullArray[rowIndex, j].ToString(),
                        //Text = (j < columnsX) ? SavedElements.array[rowIndex, j].ToString() : SavedElements.additionalVariables[rowIndex, j - columnsX].ToString(),
                        //Tag = (j < columnsX) ? SavedElements.array[rowIndex, j].ToString() : SavedElements.additionalVariables[rowIndex, j - columnsX].ToString(),
                        Background = Brushes.White,
                        BorderThickness = new Thickness(1),
                        BorderBrush = System.Windows.Media.Brushes.Black,
                        Padding = new Thickness(5)
                    };

                    Grid.SetRow(textBoxResult, rowIndex + 1);
                    Grid.SetColumn(textBoxResult, j + 1);
                    textBoxContainerResult.Children.Add(textBoxResult);


                    valueTextBoxResult = new TextBox
                    {
                        IsReadOnly = true,
                        //Text = SavedElements.arrayResult[rowIndex].ToString(),
                        Text = SavedElements.ToFraction(SavedElements.arrayResult[rowIndex]),
                        Background = Brushes.White,
                        BorderThickness = new Thickness(1),
                        BorderBrush = System.Windows.Media.Brushes.Black,
                        Padding = new Thickness(5)
                    };

                    Grid.SetRow(valueTextBoxResult, rowIndex + 1);
                    Grid.SetColumn(valueTextBoxResult, columnsX + columnsU + 1);
                    textBoxContainerResult.Children.Add(valueTextBoxResult);
                }
            }
        }




        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {

            WorkWithSupportElement workWithSupportElement = new WorkWithSupportElement();

            workWithSupportElement.CreateTextBox();

            workWithSupportElement.Show();

            this.Close();

        }

        private void Button_Click_Next(object sender, RoutedEventArgs e)
        {
            //SavedElements.ShowValues();
            //SavedElements.ShowValuesZ();
            //SavedElements.ShowValuesSign();
            //SavedElements.ShowExtremum();
            //SavedElements.ShowadditionalVariables();
            SavedElements.ShowFullArray();
            SavedElements.ShowValuesRezult();
            //SavedElements.ShowValuesDleta();

            WorkWithSupportElement workWithSupportElement = new WorkWithSupportElement();

            workWithSupportElement.CreateTextBox();

            workWithSupportElement.Show();

            this.Close();
        }
    }
}
