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
    /// Логика взаимодействия для DeltaSearch.xaml
    /// </summary>
    public partial class DeltaSearch : Window
    {
        public DeltaSearch()
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
            textBoxContainer.ColumnDefinitions.Add(new ColumnDefinition()); // Столбец для значений


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
                    Content = $"U{ i+1}",
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
                        Text = SavedElements.fullArray[i, j].ToString()
                    };

                    Grid.SetRow(textBox, i + 1);
                    Grid.SetColumn(textBox, j + 1);
                    textBoxContainer.Children.Add(textBox);
                }

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

            for (int j = 0; j < columns; j++)
            {
                TextBox deltaTextBox = new TextBox
                {
                    IsReadOnly = false,  // Make these fields editable if desired
                    BorderThickness = new Thickness(1),
                    BorderBrush = System.Windows.Media.Brushes.Black,
                    Padding = new Thickness(5)
                };

                Grid.SetRow(deltaTextBox, rows + 1);
                Grid.SetColumn(deltaTextBox, j + 1);
                textBoxContainer.Children.Add(deltaTextBox);
            }

      

            // Add empty TextBox for "Value" column
            TextBox deltaValueTextBox = new TextBox
            {
                BorderThickness = new Thickness(1),
                BorderBrush = System.Windows.Media.Brushes.Black,
                Padding = new Thickness(5)
            };

            Grid.SetRow(deltaValueTextBox, rows + 1);
            Grid.SetColumn(deltaValueTextBox, columns + 2);
            textBoxContainer.Children.Add(deltaValueTextBox);




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
