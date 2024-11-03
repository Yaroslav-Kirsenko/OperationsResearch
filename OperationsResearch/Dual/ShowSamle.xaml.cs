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
            FillStackPanels();
        }

        public static int rows = 0;
        public static int columns = 0;

        public static int[][] arrayDisplay = Array.Empty<int[]>();
        public static int[] arrayResult = Array.Empty<int>();
        public static int[] arrayZ = Array.Empty<int>();

        public static string[] arraySign = Array.Empty<string>();
        public static string Extremum;

        public void GetRowsSamle(int rowsStr)
        {
            rows = rowsStr;
            //rows = rowsStr;
            Console.WriteLine("ShowSamle");

            Console.WriteLine(rows);
        }

        public void GetColumnsSamle(int columnsStr)
        {
            columns = columnsStr;
            //columns = columnsStr;
            Console.WriteLine("ShowSamle");
            Console.WriteLine(columns);
        }

        public void GetResultSamle(int[] resultArray) {
            arrayResult = resultArray;
        }

        public void GetZSamle(int[] zArray)
        {
            arrayZ = zArray;
        }

        public void GetDisplaySamle(int[][] displayArray)
        {
            arrayDisplay = displayArray;
        }

        public void GetExtremumSamle(string extremumValue)
        {
            Extremum = extremumValue;
        }

        public void GetSignSamle(string[] signArray)
        {
            arraySign = signArray;
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
            ResultContainer.Children.Add(rowLabel);
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
            ResultContainer.Children.Add(rowLabelZ);
        }


        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {


            ShowExample showExample = new ShowExample();

            showExample.GetRows(Convert.ToString(rows));
            showExample.GetColumns(Convert.ToString(columns));

            showExample.CreateTextBox();
            showExample.Zfunc();
            showExample.Show();

            this.Hide();
        }

        private void Button_Click_Next(object sender, RoutedEventArgs e)
        {
            // Add the functionality for the "Next" button click here
            MessageBox.Show("Button 'Next' clicked!");
        }


        // Display user input data
        private void FillStackPanels()
        {
            // Очищення контейнерів перед додаванням нових даних
            ResultContainer.Children.Clear();

            // Заповнення першого контейнера даними з arrayZ
            StackPanel zPanel = new StackPanel { Orientation = Orientation.Horizontal };

            for (int i = 0; i < arrayZ.Length; i++)
            {
                zPanel.Children.Add(new TextBlock { Text = arrayZ[i].ToString() });
                zPanel.Children.Add(new TextBlock { Text = $"x{i + 1}" });

                if (i != arrayZ.Length - 1)
                {
                    zPanel.Children.Add(new TextBlock { Text = " + " });
                }
            }

            zPanel.Children.Add(new TextBlock { Text = " => " });
            zPanel.Children.Add(new TextBlock { Text = Extremum?.ToString() ?? "N/A" });

            ResultContainer.Children.Add(zPanel);

            // Заповнення другого контейнера даними з arrayDisplay
            for (int i = 0; i < rows; i++)
            {
                StackPanel panel = new StackPanel { Orientation = Orientation.Horizontal };

                for (int j = 0; j < columns; j++)
                {
                    panel.Children.Add(new TextBlock { Text = arrayDisplay[i][j].ToString() });
                    panel.Children.Add(new TextBlock { Text = $"x{j + 1}" });

                    if (j != columns - 1)
                    {
                        panel.Children.Add(new TextBlock { Text = " + " });
                    }
                }

                panel.Children.Add(new TextBlock { Text = $" {arraySign[i]} " });
                panel.Children.Add(new TextBlock { Text = arrayResult[i].ToString() });

                ResultContainer.Children.Add(panel);
            }
        }
    }
}