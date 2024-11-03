using System;

namespace OperationsResearch.Dual
{
    public class SavedElements
    {
        public static int[][] array;
        public static int[] arrayResult;
        public static int[] arrayZ;

        public static string[] arraySign;
        public static string Extremum;



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

        public void InitializeArrayResult(int rows2)
        {

            rows = rows2;

            if (rows > 0)
            {
                arrayResult = new int[rows];  // Инициализация одномерного массива res
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


        public void InitializeExtremum(string value)
        {
            if (value != null)
            {
                Extremum = value;
            }
        }


        public void InitializeArraySign(int rows2)
        {

            rows = rows2;

            if (rows > 0)
            {
                arraySign = new string[rows];  // Инициализация одномерного массива Sign
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


        public static void ShowValuesRezult()
        {
            Console.WriteLine("ARRAY result");

            for (int i = 0; i < rows; i++)
            {
                Console.Write(arrayResult[i] + " ");
            }
            Console.WriteLine();
        }


        public static void ShowValuesSign()
        {
            Console.WriteLine("ARRAY Sign");

            for (int i = 0; i < rows; i++)
            {
                Console.Write(arraySign[i] + " ");
            }
            Console.WriteLine();
        }

        public static void ShowExtremum()
        {
            Console.WriteLine("Extremum");
            Console.Write(Extremum);
        }

    }





}
