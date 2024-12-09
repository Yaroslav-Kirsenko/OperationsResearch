using System;
using System.Collections.Generic;
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
            InitializeArrayRowSign();
            MyButton.Content = "/ " + SavedElements.ToFraction(SavedElements.supportElement); // MyButton — имя кнопки
            MyButton2.Content = "* " + SavedElements.ToFraction(SavedElements.fullArray[indexU, SavedElements.supportElementColumn]) + " +"; // MyButton — имя кнопки

        }

        private void InitializeArrayRowSign()
        {
            Console.WriteLine($"{columns} Columns arrya length");
            savedElements.InitializeArrayRowSign(columns); // Указываем только количество столбцов
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
        Button rowLabel;


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
            for (int i = 0; i < SavedElements.newRows; i++)
            {
                textBoxContainer.RowDefinitions.Add(new RowDefinition());

                if (i == SavedElements.newRows - 1)
                {
                    rowLabel = new Button
                    {
                        Content = "Delta",
                        Tag = i,
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        BorderThickness = new Thickness(1),
                        BorderBrush = System.Windows.Media.Brushes.Black,
                        Background = System.Windows.Media.Brushes.SkyBlue,
                        Padding = new Thickness(5)
                    };
                }
                else
                {
                    rowLabel = new Button
                    {
                        Content = $"U{i + 1}",
                        Tag = i,
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        BorderThickness = new Thickness(1),
                        BorderBrush = System.Windows.Media.Brushes.Black,
                        Background = System.Windows.Media.Brushes.SkyBlue,
                        Padding = new Thickness(5)
                    };
                }




                rowLabel.Click += Button_Click_Side;

                Grid.SetRow(rowLabel, i + 1);
                Grid.SetColumn(rowLabel, 0);
                textBoxContainer.Children.Add(rowLabel);





                // Создаем кнопки для каждой строки
                for (int j = 0; j < columns; j++)
                {
                    Button button = new Button
                    {

                        Content = SavedElements.ToFraction(SavedElements.newFullArray[i, j]),
                        Tag = SavedElements.newFullArray[i, j].ToString(),
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

                Button headerLabelXResult = new Button
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

                Button headerLabelUResult = new Button
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
                textBoxContainerResult.RowDefinitions.Add(new RowDefinition()); ////////////////////////////////////////////////////////////////////////////////////////////////////////////

                List<string> rowSignLabel = new List<string>();

               

                rowSignLabel.Add($"U{i + 1}");
                for (int j = 0; j < rows; j++)
                {
                    rowSignLabel.Add($"X{j + 1}");

                   
                }


                int rowSign = i;

                SavedElements.arrayRowSign[rowSign] = rowSignLabel[0];

                ComboBox rowLabelResult = new ComboBox        ///////////////////////////////////////////////////////////////
                {
                    //Content = $"U{i + 1}",

                    ItemsSource = rowSignLabel,
                    SelectedIndex = 0,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    BorderThickness = new Thickness(1),
                    BorderBrush = System.Windows.Media.Brushes.Black,
                    Background = System.Windows.Media.Brushes.SkyBlue,
                    Padding = new Thickness(5)
                };


                rowLabelResult.SelectionChanged += (sender, e) =>
                {
                    string selectedSign = rowLabelResult.SelectedItem.ToString();
                    Console.WriteLine($"{rowSign} index, {selectedSign} data");
                    SavedElements.arrayRowSign[rowSign] = selectedSign;
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

            Button deltaLabelResult = new Button
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

        public int indexU;

        private void Button_Click_Side(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button != null && button.Tag is int index)
            {
                indexU = index;
                Console.WriteLine($"Индекс кнопки: {indexU}"); // Выводим индекс кнопки из Tag

                // Логика изменения цвета
                if (button.Background == Brushes.SkyBlue)
                {
                    button.Background = Brushes.LightGreen; // Меняем цвет на зеленый
                }
                else
                {
                    button.Background = Brushes.SkyBlue; // Меняем цвет на голубой
                }
            }
            else
            {
                Console.WriteLine("Ошибка: Tag кнопки не определён или имеет неверный формат.");
            }
        }


        public int indexDelta;

        private void Button_Click_Side_Delta(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button != null && button.Tag is int index)
            {
                indexDelta = rows;
                Console.WriteLine($"Индекс кнопки: {indexU}"); // Выводим индекс кнопки из Tag

                // Логика изменения цвета
                if (button.Background == Brushes.SkyBlue)
                {
                    button.Background = Brushes.LightGreen; // Меняем цвет на зеленый
                }
                else
                {
                    button.Background = Brushes.SkyBlue; // Меняем цвет на голубой
                }
            }
            else
            {
                Console.WriteLine("Ошибка: Tag кнопки не определён или имеет неверный формат.");
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
                        Text = SavedElements.ToFraction(SavedElements.newFullArray[rowIndex, j]),
                        //Text = SavedElements.fullArray[rowIndex, j].ToString(),
                        Tag = SavedElements.newFullArray[rowIndex, j].ToString(),
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
                        Text = SavedElements.ToFraction(SavedElements.newArrayResult[rowIndex]),
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




        private void Button_Click_SearhElement(object sender, RoutedEventArgs e)
        {

            Button button = sender as Button;
            if (button != null)
            {
                // Индексы строки и столбца, где находится supportElement
                int rowIndex = SavedElements.supportElementRow;
                int columnIndex = SavedElements.supportElementColumn;



                // Получаем значение supportElement
                double supportElementValue = SavedElements.fullArray[indexU, columnIndex];

                // Проверяем, чтобы деление на 0 не происходило
                if (supportElementValue == 0)
                {
                    MessageBox.Show("Support element value cannot be zero!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Делим каждый элемент строки на supportElement
                for (int j = 0; j < SavedElements.newFullArray.GetLength(1); j++)
                {
                    if (indexU != 0)
                    {
                        SavedElements.newFullArray[indexU, j] = (SavedElements.newFullArray[rowIndex, j] * (supportElementValue * -1)) + SavedElements.newFullArray[indexU, j];
                    }
                    else
                    {
                        SavedElements.newFullArray[indexU, j] = (SavedElements.newFullArray[rowIndex, j] * (supportElementValue * -1)) + SavedElements.newFullArray[indexU, j];
                    }

                }

                if (indexU != 0)
                {
                    SavedElements.arrayResult[indexU] = (SavedElements.newArrayResult[rowIndex] * (supportElementValue * -1)) + SavedElements.newArrayResult[indexU];
                }
                else
                {
                    SavedElements.arrayResult[indexU] = (SavedElements.newArrayResult[rowIndex] * (supportElementValue * -1)) + SavedElements.newArrayResult[indexU];

                }

                // Добавляем строки с номерами и кнопками вместо текстовых полей

                for (int j = 0; j < columns; j++)
                {
                    textBoxResult = new TextBox
                    {
                        IsReadOnly = true,
                        Text = SavedElements.ToFraction(SavedElements.newFullArray[indexU, j]),
                        //Text = SavedElements.fullArray[rowIndex, j].ToString(),
                        Tag = SavedElements.newFullArray[indexU, j].ToString(),
                        //Text = (j < columnsX) ? SavedElements.array[rowIndex, j].ToString() : SavedElements.additionalVariables[rowIndex, j - columnsX].ToString(),
                        //Tag = (j < columnsX) ? SavedElements.array[rowIndex, j].ToString() : SavedElements.additionalVariables[rowIndex, j - columnsX].ToString(),
                        Background = Brushes.White,
                        BorderThickness = new Thickness(1),
                        BorderBrush = System.Windows.Media.Brushes.Black,
                        Padding = new Thickness(5)
                    };

                    Grid.SetRow(textBoxResult, indexU + 1);
                    Grid.SetColumn(textBoxResult, j + 1);
                    textBoxContainerResult.Children.Add(textBoxResult);


                    valueTextBoxResult = new TextBox
                    {
                        IsReadOnly = true,
                        //Text = SavedElements.arrayResult[rowIndex].ToString(),
                        Text = SavedElements.ToFraction(SavedElements.newArrayResult[indexU]),
                        Background = Brushes.White,
                        BorderThickness = new Thickness(1),
                        BorderBrush = System.Windows.Media.Brushes.Black,
                        Padding = new Thickness(5)
                    };

                    Grid.SetRow(valueTextBoxResult, indexU + 1);
                    Grid.SetColumn(valueTextBoxResult, columnsX + columnsU + 1);
                    textBoxContainerResult.Children.Add(valueTextBoxResult);
                }
            }
            indexU = 0;
        }

        private void Button_Click_Next(object sender, RoutedEventArgs e)
        {
            //SavedElements.ShowValues();
            //SavedElements.ShowValuesZ();
            //SavedElements.ShowValuesSign();
            //SavedElements.ShowExtremum();
            //SavedElements.ShowadditionalVariables();
            SavedElements.ShowFullArray();
            //SavedElements.ShowValuesRezult();
            SavedElements.ShowValuesArrayRowSign();
            //SavedElements.ShowValuesDleta();



            WorkWithSupportElement workWithSupportElement = new WorkWithSupportElement();

            workWithSupportElement.CreateTextBox();

            workWithSupportElement.Show();

            this.Close();
        }
    }
}



