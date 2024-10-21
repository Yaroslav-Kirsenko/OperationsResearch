using System;
using System.Windows;
using System.Windows.Controls;

namespace OperationsResearch.Dual
{
    public partial class ShowExample : Window
    {
        public ShowExample()
        {
            InitializeComponent();
        }

        public int rows = 0;
        public int columns = 0;

        public void GetRows(string rowsStr)
        {
            rows = Convert.ToInt32(rowsStr);
            Console.WriteLine(rows);
        }

        public void GetColumns(string columnsStr)
        {
            columns = Convert.ToInt32(columnsStr);
            Console.WriteLine(columns);
        }

        public void CreateTextBox()
        {
            
            textBoxContainer.Children.Clear();
            textBoxContainer.RowDefinitions.Clear();
            textBoxContainer.ColumnDefinitions.Clear();

           
            textBoxContainerZ.Children.Clear();
            textBoxContainerZ.RowDefinitions.Clear();
            textBoxContainerZ.ColumnDefinitions.Clear();

            
            textBoxContainer.RowDefinitions.Add(new RowDefinition());
            textBoxContainerZ.RowDefinitions.Add(new RowDefinition());

            
            textBoxContainer.ColumnDefinitions.Add(new ColumnDefinition());
            textBoxContainerZ.ColumnDefinitions.Add(new ColumnDefinition());

           
            for (int j = 0; j < columns; j++)
            {
                textBoxContainerZ.ColumnDefinitions.Add(new ColumnDefinition());

                Label zLabel = new Label
                {
                    Content = $"X{j + 1}",
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    Width = 100,
                    Height = 30,
                    Margin = new Thickness(5)
                };

                Grid.SetRow(zLabel, 0);
                Grid.SetColumn(zLabel, j + 1);
                textBoxContainerZ.Children.Add(zLabel);
            }

            
            for (int j = 0; j < columns; j++)
            {
                textBoxContainer.ColumnDefinitions.Add(new ColumnDefinition());

                Label headerLabel = new Label
                {
                    Content = $"X{j + 1}",
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    Width = 100,
                    Height = 30,
                    Margin = new Thickness(5)
                };

                Grid.SetRow(headerLabel, 0);
                Grid.SetColumn(headerLabel, j + 1);
                textBoxContainer.Children.Add(headerLabel);
            }

            
            for (int i = 0; i < rows; i++)
            {
                
                textBoxContainer.RowDefinitions.Add(new RowDefinition());
                textBoxContainerZ.RowDefinitions.Add(new RowDefinition());

                
                Label zRowLabel = new Label
                {
                    Content = $"Z{i + 1}",
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    Width = 100,
                    Height = 30,
                    Margin = new Thickness(5)
                };

                Grid.SetRow(zRowLabel, i + 1);
                Grid.SetColumn(zRowLabel, 0);
                textBoxContainerZ.Children.Add(zRowLabel);

                
                Label rowLabel = new Label
                {
                    Content = $"{i + 1}",
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    Width = 100,
                    Height = 30,
                    Margin = new Thickness(5)
                };

                Grid.SetRow(rowLabel, i + 1);
                Grid.SetColumn(rowLabel, 0);
                textBoxContainer.Children.Add(rowLabel);

                
                for (int j = 0; j < columns; j++)
                {
                    TextBox textBox = new TextBox
                    {
                        Width = 100,
                        Height = 30,
                        Margin = new Thickness(5)
                    };

                    Grid.SetRow(textBox, i + 1);
                    Grid.SetColumn(textBox, j + 1);
                    textBoxContainer.Children.Add(textBox);
                }
            }
        }
    }
}
