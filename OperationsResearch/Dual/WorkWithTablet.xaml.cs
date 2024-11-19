using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
        }


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

                //rowLabel.Click += Button_Click_Side;


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

                    //button.Click += Button_Click; // добавляем обработчик нажатия кнопки

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

                Button deltaButton= new Button
                {
                    Content = SavedElements.arrayDelta[j].ToString(),
                    Tag = SavedElements.arrayDelta[j].ToString(),
                    Background = Brushes.White,
                    BorderThickness = new Thickness(1),
                    BorderBrush = System.Windows.Media.Brushes.Black,
                    Padding = new Thickness(5)

                };


                Grid.SetRow(deltaButton, rows + 1);
                Grid.SetColumn(deltaButton, j + 1);
                textBoxContainer.Children.Add(deltaButton);
            }
        }


        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {


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

            WorkWithSupportElement workWithSupportElement = new WorkWithSupportElement();

            workWithSupportElement.Show();

            this.Close();
        }

    }
}
