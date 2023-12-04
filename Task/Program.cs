using System;
class Program
{
    static void Main()
    {
        int N=3, M=6;
        //bool check0 = false, check1, check2, check3, check4, check5 = false;
        //Console.WriteLine("Enter matrix size:");
        //do
        //{
        //    check1 = false; check2 = false;
        //    Console.Write("N = ");
        //    do
        //    {
        //        check1 = int.TryParse(Console.ReadLine(), out N);
        //    } while (check1 == false);
        //    Console.Write("M = ");
        //    do
        //    {
        //        check2 = int.TryParse(Console.ReadLine(), out M);
        //    } while (check2 == false);
        //    if (N > 0 && M > 0) check0 = true;
        //    else Console.WriteLine("N and M must be greater than 0 to create matrix");
        //} while (check0 == false);
        int[,] array = new int[N, M];
        int min = -10, max=10;
        //Console.Write("Enter the range of number generation\n");
        //do
        //{
        //    check3 = false; check4 = false;
        //    Console.Write("Minimum generated value: ");
        //    do
        //    {
        //        check3 = int.TryParse(Console.ReadLine(), out min);
        //    } while (check3 == false);
        //    Console.Write("Maximum generated value: ");
        //    do
        //    {
        //        check4 = int.TryParse(Console.ReadLine(), out max);
        //    } while (check4 == false);
        //    if (min < max) check5 = true;
        //    else Console.WriteLine("Minimum value must be greater than maximum! Try again.");
        //} while (check5 == false);
        array = arrayGen(array, min, max);
        printArray(array);
        positiveElementsCounter(array);
        maxElementNumberThatRepeat(array);
    }
    static int[,] arrayGen(int[,] array, int min, int max)
    {
        Random rnd = new Random();
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = rnd.Next(min, max + 1);
            }
        }
        return array;
    }
    static void printArray(int[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write(" {0}  ", array[i, j]);
            }
            Console.WriteLine();
        }
    }
    static void positiveElementsCounter(int[,] array)
    {
        int counter = 0;
        for(int i = 0;i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (array[i,j] > 0) counter++;
            }
        }
        Console.WriteLine("Number of positive elements in the array: {0}", counter);
    }

    static void maxElementNumberThatRepeat(int[,] array)
    {
        int maxNumber = int.MinValue;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                int comparision = array[i, j];
                for (int i1 = 0; i1 < array.GetLength(0); i1++)
                {
                    for(int j1 = 0; j1 < array.GetLength(1);j1++)
                    {
                        if (i != i1 && j != j1)
                        {
                            if (comparision == array[i1, j1])
                            {
                                if (maxNumber < array[i, j])
                                {
                                    maxNumber = array[i, j];
                                }
                            }
                        }
                    }
                } 
            }
        }
        if (maxNumber == int.MinValue) Console.WriteLine("Array does not have numbers that repeat");
        else Console.WriteLine("Maximum number that repeats in the array: {0}", maxNumber);
    }
}