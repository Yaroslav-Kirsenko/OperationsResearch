using System;
using System.Windows;
using System.Collections.Generic;

using System.Windows.Controls;
using System.Windows.Documents;
using System.ComponentModel;

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
            LoadData();
            DataContext = this; // Встановлюємо DataContext для прив'язки
        }

        public static string rows = "";
        public static string columns = "";

        public int[,] arrayDisplay { get; set; }
        public int[] arrayResult { get; set; }
        public int[] arrayZ { get; set; }
        public string[] arraySign { get; set; }
        public string Extremum { get; set; }

        public int samleRows { get; set; }
        public int samleColumns { get; set; }

        private void LoadData()
        {
            // Перетворення `int[][]` на колекцію рядків для відображення
            arrayDisplay = SavedElements.array;

            // Ініціалізація даних з `SavedElements`
            arrayResult = SavedElements.arrayResult;
            arrayZ = SavedElements.arrayZ ?? new int[0];
            arraySign = SavedElements.arraySign;
            Extremum = SavedElements.Extremum;

            samleRows = SavedElements.rows;
            samleColumns = SavedElements.columns;

            // Сповіщення про зміни властивостей
            OnPropertyChanged(nameof(arrayDisplay));
            OnPropertyChanged(nameof(arrayResult));
            OnPropertyChanged(nameof(arrayZ));
            OnPropertyChanged(nameof(arraySign));
            OnPropertyChanged(nameof(Extremum));
            OnPropertyChanged(nameof(samleRows));
            OnPropertyChanged(nameof(samleColumns));

            // Відображення даних
            FillStackPanels();

        }

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
                    zPanel.Children.Add(new TextBlock { Text = " + " }); ////// ТУТ ИСПРАВИТЬ
                }
            }

            zPanel.Children.Add(new TextBlock { Text = " => " });
            zPanel.Children.Add(new TextBlock { Text = Extremum?.ToString() ?? "N/A" });

            ResultContainer.Children.Add(zPanel);

            // Заповнення другого контейнера даними з arrayDisplay
            for (int i = 0; i < samleRows; i++)
            {
                StackPanel panel = new StackPanel { Orientation = Orientation.Horizontal };

                for (int j = 0; j < samleColumns; j++)
                {
                    panel.Children.Add(new TextBlock { Text = arrayDisplay[i,j].ToString() });
                    panel.Children.Add(new TextBlock { Text = $"x{j + 1}" });

                    if (j != samleColumns - 1)
                    {
                        panel.Children.Add(new TextBlock { Text = " + " }); ////// ТУТ ИСПРАВИТЬ
                    }
                }

                panel.Children.Add(new TextBlock { Text = $" {arraySign[i]} " });
                panel.Children.Add(new TextBlock { Text = arrayResult[i].ToString() });

                ResultContainer.Children.Add(panel);
            }
        }




        // Реалізація INotifyPropertyChanged для оновлення UI при зміні даних
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }



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



        // Нові методи для відображення інформації з SavedElements
        private void Button_Click_ShowSavedData(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Button_Click_ShowSavedData called");
            ShowSavedArray();
            ShowSavedArrayZ();
            ShowSavedArrayResult();
            ShowSavedArraySign();
            ShowSavedExtremum();
        }

        public void ShowSavedArray()
        {
            Console.WriteLine("ShowSavedArray called");
            SavedElements.ShowValues();
        }

        public void ShowSavedArrayZ()
        {
            Console.WriteLine("ShowSavedArrayZ called");
            SavedElements.ShowValuesZ();
        }

        public void ShowSavedArrayResult()
        {
            Console.WriteLine("ShowSavedArrayResult called");
            SavedElements.ShowValuesRezult();
        }

        public void ShowSavedArraySign()
        {
            Console.WriteLine("ShowSavedArraySign called");
            SavedElements.ShowValuesSign();
        }

        public void ShowSavedExtremum()
        {
            Console.WriteLine("ShowSavedExtremum called");
            SavedElements.ShowExtremum();
        }
    }
}