using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OperationsResearch.DualServices
{
    public class ShowExampleService
    {

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

        public void CreateTextBox(TextBox textBox) {

            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < columns; j++) {
                    TextBox text = new TextBox();                
                }
            }
        }

    }
}