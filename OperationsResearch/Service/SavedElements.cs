using System;

namespace OperationsResearch.Dual
{
    public class SavedElements
    {
        public static int[][] array;

        public static int[] arrayZ;

        public static int rows = 0;
        public static int columns = 0;

        public void InitializeArray(int rows1, int columns1)
        {
            rows = rows1;
            columns = columns1;

            if (rows > 0 && columns > 0)
            {
                array = new int[rows][];
                for (int i = 0; i < rows; i++)
                {
                    array[i] = new int[columns];
                }
            }
        }



        public void InitializeArrayZ(int columns1)
        {
            columns = columns1;

            if (columns > 0)
            {
                arrayZ = new int[columns];  // Инициализация одномерного массива Z
            }
        }

        public static void ShowValues()
        {

            Console.WriteLine("ARRAY");

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(array[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        // Метод для вывода значений массива Z в консоль
        public static void ShowValuesZ()
        {
            Console.WriteLine("ARRAY Z");

            for (int j = 0; j < columns; j++)
            {
                Console.Write(arrayZ[j] + " ");
            }
            Console.WriteLine();
        }
    }
}
