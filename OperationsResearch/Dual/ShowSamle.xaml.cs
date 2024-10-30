using System;
using System.Windows;
using System.Collections.Generic;

using System.Windows.Controls;
using System.Windows.Documents;

namespace OperationsResearch.Dual
{
    /// <summary>
    /// Логика взаимодействия для ShowSamle.xaml
    /// </summary>
    public partial class ShowSamle : Window
    {


        public ShowSamle()
        {
            InitializeComponent();
        }

        public static string rows = "";
        public static string columns ="";


        public void GetRowsSamle(int rowsStr)
        {
            rows = Convert.ToString(rowsStr);
            //rows = rowsStr;
            Console.WriteLine("ShowSamle");

            Console.WriteLine(rows);
        }


        public void GetColumnsSamle(int columnsStr)
        {
            columns = Convert.ToString(columnsStr);
            //columns = columnsStr;
            Console.WriteLine("ShowSamle");
            Console.WriteLine(columns);
        }

        // БЕРУ ИНФУ С ТАБЛИЧКИ LABEL X!!!!!!!
        public void GetValueLabelX(Label label)
        {
            // Получаем текст метки
            string labelContent = label.Content.ToString();


            Label rowLabel = new Label
            {
                Content = labelContent,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                Margin = new Thickness(5)
            };

            // Добавляем Label в StackPanel для отображения
            LabelsContainer.Children.Add(rowLabel);
        }

        // БЕРУ ИНФУ С  Z - ФУНКЦИИ LABEL X!!!!!!!
        public void GetValueZX(Label label)
        {

            string labelContent = label.Content.ToString();

            Console.WriteLine("Z - функция");
            Console.WriteLine(labelContent);


            //listZX.Add(new Label { Content = labelContent });

            Label rowLabelZ = new Label
            {
                Content = labelContent,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                Margin = new Thickness(5)
            };

            // Добавляем Label в StackPanel для отображения
            LabelsContainer.Children.Add(rowLabelZ);

        }


        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {


            ShowExample showExample = new ShowExample();

            showExample.GetRows(rows);
            showExample.GetColumns(columns);

            showExample.CreateTextBox();
            showExample.Zfunc();
            showExample.Show();

            this.Hide();
        }

        private void Button_Click_Next(object sender, RoutedEventArgs e)
        {
            CreateNewElements createNewElements = new CreateNewElements();

            createNewElements.GetRows(rows);
            createNewElements.GetColumns(columns);

            createNewElements.CreateTextBox();
            createNewElements.Zfunc();

            createNewElements.Show();

            this.Hide();

        }
    }
}