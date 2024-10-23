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

        public Label label = new Label();

        public int rows = 0;
        public int columns = 0;

        public List<Label> listTableX = new List<Label>();

        public List<Label> listZX = new List<Label>();

        public void GetRowsSamle(string rowsStr)
        {
            rows = Convert.ToInt32(rowsStr);
            //Console.WriteLine(rows);
        }


        public void GetColumnsSamle(string columnsStr)
        {
            columns = Convert.ToInt32(columnsStr);
            //Console.WriteLine(columns);
        }

        // БЕРУ ИНФУ С ТАБЛИЧКИ LABEL X!!!!!!!
        public void GetValueLabelX(Label label)
        {

            string labelContent = label.Content.ToString();

            Console.WriteLine("Табличка");
            Console.WriteLine(labelContent);

            listTableX.Add(new Label { Content = labelContent });

        }

        // БЕРУ ИНФУ С  Z - ФУНКЦИИ LABEL X!!!!!!!
        public void GetValueZX(Label label)
        {

            string labelContent = label.Content.ToString();

            Console.WriteLine("Z - функция");
            Console.WriteLine(labelContent);


            listZX.Add(new Label { Content = labelContent });

        }


        //public void GetTextBoxInfo(string content)
        //{
        //    displayLabel.Content = content;
        //}

        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            ShowExample showExample = new ShowExample();

            showExample.Show();

            this.Close();
        }
    }
}