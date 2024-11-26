﻿using System;

namespace OperationsResearch.Dual
{
    public class SavedElements
    {

        public static double supportElement;

        public static int supportElementRow;
        public static int supportElementColumn;

        public static double[,] fullArray;


        public static double[,] additionalVariables;
        public static double[,] array;
        public static double[] arrayResult;
        public static double[] arrayDelta;


        public static double[,] fullArrayNewTablet;


        public static double[,] additionalVariablesNewTablet;
        public static double[,] arrayNewTablet;
        public static double[] arrayResultNewTablet;
        public static double[] arrayDeltaNewTablet;

        public static int[] arrayZ;


        public static string[] arraySign;
        public static string Extremum;



        public static int rows = 0;
        public static int columns = 0;


        public static int rowsAdditional = 0;
        public static int columnsAdditional = 0;

        public static int columnsDelta = 0;

        public static int SetRowsFullArray()
        {
            int rows1 = fullArray.GetLength(0);

            return rows;
        }

        public static int SetColumnsFullArray()
        {

            int cols = fullArray.GetLength(1);
            return cols;
        }

        public static int SetRowsX()
        {
            int rows1 = array.GetLength(0);

            return rows;
        }

        public static int SetColumnsX()
        {

            int cols = array.GetLength(1);
            return cols;
        }

        public static int SetRowsU()
        {
            int rows1 = additionalVariables.GetLength(0);

            return rows;
        }

        public static int SetColumnsU()
        {

            int cols = additionalVariables.GetLength(1);
            return cols;
        }


        public void InitializeFullArray(int rows1, int columns1)
        {
            rows = rows1;
            columns = columns1;

            if (rows > 0 && columns > 0)
            {
                fullArray = new double[rows, columns];
            }
        }

        public void InitializeArray(int rows1, int columns1)
        {
            rows = rows1;
            columns = columns1;

            if (rows > 0 && columns > 0)
            {
                array = new double[rows, columns];
            }
        }



        public void InitializeArrayResult(int rows2)
        {

            rows = rows2;

            if (rows > 0)
            {
                arrayResult = new double[rows];  // Инициализация одномерного массива res
            }
        }


        public void InitializeAdditionalVariables(int rows1, int columns1)
        {
            rowsAdditional = rows1;
            columnsAdditional = columns1;
            if (rowsAdditional > 0 && columnsAdditional > 0)
            {
                if (rowsAdditional > columnsAdditional)
                {
                    int value = rowsAdditional - columnsAdditional;
                    additionalVariables = new double[rowsAdditional, columnsAdditional + value];
                }
                else if (columnsAdditional > rowsAdditional)            ///////////////////////////////
                {
                    columnsAdditional = rowsAdditional;
                    additionalVariables = new double[rowsAdditional, columnsAdditional];

                    Console.WriteLine("columnsAdditional = " + columnsAdditional);
                }
                else
                {
                    additionalVariables = new double[rowsAdditional, columnsAdditional];
                }
            }
        }

        public void InitializeArrayZ(int columns1)                /////////////////////////////////////////////////////////////////////////////////////////////
        {
            columns = columns1;

            if (columns > 0)
            {
                arrayZ = new int[columns];  // Инициализация одномерного массива Z
            }
        }

        public void InitializeArrayDelta(int columns1, int columns2)                /////////////////////////////////////////////////////////////////////////////////////////////
        {
            columnsDelta = columns1 + columns2 + 1;

            if (columnsDelta > 0)
            {
                arrayDelta = new double[columnsDelta];  // Инициализация одномерного массива Delta
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


        public static void ShowFullArray()
        {

            Console.WriteLine("ShowFullArray");


            int rows1 = fullArray.GetLength(0);
            int cols1 = fullArray.GetLength(1);

            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols1; j++)
                {
                    Console.Write(fullArray[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static void ShowValues()
        {

            Console.WriteLine("ARRAY");

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }


        public static void ShowSupportElement()
        {

            Console.WriteLine("Show SupportElement");
            Console.WriteLine(supportElement);

        }

        public static void ShowSupportElementRowAndColumn()
        {

            Console.WriteLine("Show SupportElement");
            Console.WriteLine("Row "+ supportElementRow);
            Console.WriteLine("Column " + supportElementColumn);

        }



        public static void ShowadditionalVariables()
        {

            Console.WriteLine("ShowadditionalVariables");

            for (int i = 0; i < rowsAdditional; i++)
            {
                for (int j = 0; j < columnsAdditional; j++)
                {
                    Console.Write(additionalVariables[i, j] + " ");
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


        // Метод для вывода значений массива Z в консоль
        public static void ShowValuesDleta()
        {
            Console.WriteLine("ARRAY Delta");

            for (int j = 0; j < columnsDelta; j++)
            {
                Console.Write(arrayDelta[j] + " ");
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






        //    public ShowSamle showSamle = new ShowSamle();

        //    //showSamle.GetDisplaySamle(array);

        //    public SavedElements()
        //    {
        //        showSamle = new ShowSamle();
        //        showSamle.GetDisplaySamle(array);
        //    }
        //}

        public void InitializeFullArrayNewTablet(int rows1, int columns1)
        {
            rows = rows1;
            columns = columns1;

            if (rows > 0 && columns > 0)
            {
                fullArrayNewTablet = new double[rows, columns];
            }
        }

        public void InitializeArrayNewTablet(int rows1, int columns1)
        {
            rows = rows1;
            columns = columns1;

            if (rows > 0 && columns > 0)
            {
                array = new double[rows, columns];
            }
        }



        public void InitializeArrayResultNewTablet(int rows2)
        {

            rows = rows2;

            if (rows > 0)
            {
                arrayResult = new double[rows];  // Инициализация одномерного массива res
            }
        }


        public void InitializeAdditionalVariablesNewTablet(int rows1, int columns1)
        {
            rowsAdditional = rows1;
            columnsAdditional = columns1;
            if (rowsAdditional > 0 && columnsAdditional > 0)
            {
                if (rowsAdditional > columnsAdditional)
                {
                    int value = rowsAdditional - columnsAdditional;
                    additionalVariables = new double[rowsAdditional, columnsAdditional + value];
                }
                else if (columnsAdditional > rowsAdditional)            ///////////////////////////////
                {
                    columnsAdditional = rowsAdditional;
                    additionalVariables = new double[rowsAdditional, columnsAdditional];

                    Console.WriteLine("columnsAdditional = " + columnsAdditional);
                }
                else
                {
                    additionalVariables = new double[rowsAdditional, columnsAdditional];
                }
            }
        }

        public static void ShowFullArrayNewTablet()
        {

            Console.WriteLine("ShowFullArrayNewTablet");


            int rows1 = fullArray.GetLength(0);
            int cols1 = fullArray.GetLength(1);

            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols1; j++)
                {
                    Console.Write(fullArray[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static void ShowValuesNewTablet()
        {

            Console.WriteLine("ARRAYNewTablet");

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }


        public static void ShowSupportElementNewTablet()
        {

            Console.WriteLine("Show SupportElement");
            Console.WriteLine(supportElement);

        }

        public static void ShowSupportElementRowAndColumnNewTablet()
        {

            Console.WriteLine("Show SupportElement");
            Console.WriteLine("Row " + supportElementRow);
            Console.WriteLine("Column " + supportElementColumn);

        }



        public static void ShowadditionalVariablesNewTablet()
        {

            Console.WriteLine("ShowadditionalVariables");

            for (int i = 0; i < rowsAdditional; i++)
            {
                for (int j = 0; j < columnsAdditional; j++)
                {
                    Console.Write(additionalVariables[i, j] + " ");
                }
                Console.WriteLine();
            }
        }







        // Метод для вывода значений массива Z в консоль
        public static void ShowValuesZNewTablet()
        {
            Console.WriteLine("ARRAY Z");

            for (int j = 0; j < columns; j++)
            {
                Console.Write(arrayZ[j] + " ");
            }
            Console.WriteLine();
        }


        // Метод для вывода значений массива Z в консоль
        public static void ShowValuesDletaNewTablet()
        {
            Console.WriteLine("ARRAY Delta");

            for (int j = 0; j < columnsDelta; j++)
            {
                Console.Write(arrayDelta[j] + " ");
            }
            Console.WriteLine();
        }


        public static void ShowValuesRezultNewTablet()
        {
            Console.WriteLine("ARRAY result");

            for (int i = 0; i < rows; i++)
            {
                Console.Write(arrayResult[i] + " ");
            }
            Console.WriteLine();
        }


        public static void ShowValuesSignNewTablet()
        {
            Console.WriteLine("ARRAY Sign");

            for (int i = 0; i < rows; i++)
            {
                Console.Write(arraySign[i] + " ");
            }
            Console.WriteLine();
        }

        public static void ShowExtremumNewTablet()
        {
            Console.WriteLine("Extremum");
            Console.Write(Extremum);
        }


    }
}
