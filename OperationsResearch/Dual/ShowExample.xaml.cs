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
    /// Логика взаимодействия для ShowExample.xaml
    /// </summary>
    public partial class ShowExample : Window
    {
        public ShowExample()
        {
            InitializeComponent();
        }


        //public void UpdateLabelContent(string content)
        //{
        //    // Предположим, что Label с именем "displayLabel"
        //    displayLabel.Content = content;
        //}


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

        //public void CreateTextBox()
        //{
        //    // Очистим контейнер перед добавлением новых TextBox
        //    textBoxContainer.Children.Clear();

        //    for (int i = 0; i < rows; i++)
        //    {
        //        for (int j = 0; j < columns; j++)
        //        {
        //            // Создаем TextBox
        //            TextBox textBox = new TextBox();
        //            textBox.Width = 100;
        //            textBox.Height = 30;
        //            textBox.Margin = new Thickness(5); // Добавим отступы для красоты

        //            // Добавляем его в StackPanel
        //            textBoxContainer.Children.Add(textBox);
        //        }

        //    }
        //}

        public void CreateTextBox()
        {
            // Очистим контейнер перед добавлением новых TextBox
            textBoxContainer.Children.Clear();
            textBoxContainer.RowDefinitions.Clear();
            textBoxContainer.ColumnDefinitions.Clear();

            // Добавляем строки в Grid
            for (int i = 0; i < rows; i++)
            {
                textBoxContainer.RowDefinitions.Add(new RowDefinition());

            }

            // Добавляем столбцы в Grid
            for (int j = 0; j < columns; j++)
            {
                textBoxContainer.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Label label = new Label();
                    label.Content = i+1;
                    label.Width = 100;
                    label.Height = 30;
                    label.Margin = new Thickness(5); // Добавим отступы
                    Grid.SetRow(label, i);
                    Grid.SetColumn(label, j);
                    textBoxContainer.Children.Add(label);

                }
            }


            // Создаем TextBox и размещаем их в нужных строках и столбцах
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {

                    // Создаем TextBox
                    TextBox textBox = new TextBox();
                    textBox.Width = 100;
                    textBox.Height = 30;
                    textBox.Margin = new Thickness(5); // Добавим отступы

                    // Задаем позицию TextBox в Grid
                    Grid.SetRow(textBox, i);
                    Grid.SetColumn(textBox, j);

                    // Добавляем TextBox в Grid
                    textBoxContainer.Children.Add(textBox);
                }
            }
        }


    }
}
