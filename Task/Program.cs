using System;
class Program
{
    static void Main()
    {
        int N=5, M=5;
        bool check0 = false, check1, check2, check3, check4, check5 = false;
        Console.WriteLine("Enter matrix size:");
        do
        {
            check1 = false; check2 = false;
            Console.Write("N = ");
            do
            {
                check1 = int.TryParse(Console.ReadLine(), out N);
            } while (check1 == false);
            Console.Write("M = ");
            do
            {
                check2 = int.TryParse(Console.ReadLine(), out M);
            } while (check2 == false);
            if (N > 0 && M > 0) check0 = true;
            else Console.WriteLine("N and M must be greater than 0 to create matrix");
        } while (check0 == false);
        int[,] array = new int[N, M];
        int min = -10, max=10;
        Console.Write("Enter the range of number generation\n");
        do
        {
            check3 = false; check4 = false;
            Console.Write("Minimum generated value: ");
            do
            {
                check3 = int.TryParse(Console.ReadLine(), out min);
            } while (check3 == false);
            Console.Write("Maximum generated value: ");
            do
            {
                check4 = int.TryParse(Console.ReadLine(), out max);
            } while (check4 == false);
            if (min < max) check5 = true;
            else Console.WriteLine("Minimum value must be greater than maximum! Try again.");
        } while (check5 == false);
        array = arrayGen(array, min, max);
        printArray(array);
        positiveElementsCounter(array);
        maxElementNumberThatRepeat(array);
        numberOfRowsThatDontContainZeros(array);
        numberOfColumnsThatContainZereos(array);
        rowNumberThatContainsLongestSeriesOfIdenticalElements(array);
        multiplOfElementsInRowsWithoutNegNumbers(array);
        maxSumOfParallelDiagToMainDiag(array, N, M);
        sumOfElementsInColumnsWithoutNegEl(array);
        minSumOfAbsoluteElementsFromDiagParallelToSecondaryDiag(array, N, M);
        sumOfElementsInColumnsWithNegEl(array);
        transposeMatrix(array);
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
                Console.Write($"{array[i, j],5}");
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
    static void numberOfRowsThatDontContainZeros(int[,] array) 
    {
        int counter = array.GetLength(0);
        for (int i = 0; i < array.GetLength(0); i++)
        {
            bool isRowContainsZeroes = false;
            for (int j = 0; j < array.GetLength(1); j++)
            { 
                if (array[i,j] == 0) 
                {
                    isRowContainsZeroes = true; break;
                }
            }
            if (isRowContainsZeroes == true) counter--; 
        }
        if (counter == array.GetLength(0)) Console.WriteLine("Array doesn`t contain 0");
        else Console.WriteLine("Number of rows in array that don't contain 0: {0}", counter);
    }
    static void numberOfColumnsThatContainZereos(int[,] array) 
    {
        int counter = 0;
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                if (array[i, j] == 0)
                {
                    counter++; break;
                }
            }
        }
        if (counter == 0) Console.WriteLine("Array doesn`t contain 0");
        else Console.WriteLine("Number of columns in array that contain 0: {0}", counter);
    }
    static void rowNumberThatContainsLongestSeriesOfIdenticalElements(int[,] array) 
    {
        int[] rowNumber = new int[array.GetLength(0)];
        rowNumber[0] = -1;
        int maxCountOfRepeating = 1;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            
            for (int j = 0; j < array.GetLength(1);j++) 
            {
                int repeatCheck = array[i, j];
                int counter = 1;
                for (int j1 = j + 1; j1 < array.GetLength(1); j1++)
                {
                    if(repeatCheck == array[i,j1])
                    {
                        counter++;
                    }
                }
                if (maxCountOfRepeating <= counter)
                {
                    maxCountOfRepeating = counter;
                    rowNumber[i] = maxCountOfRepeating;
                }
            }
        }
        if (rowNumber[0] != 1)
        {
            Console.Write("Number of row that have the longest series of indentical elements: ");
            int maxNumber = -1;
            for (int i = 0; i < rowNumber.GetLength(0); i++)
            {
                if (rowNumber[i] > maxNumber) maxNumber = rowNumber[i];
            }
            for (int i = 0; i < rowNumber.GetLength(0); i++)
            {
                if (rowNumber[i] == maxNumber) Console.Write("{0} ", i + 1);
            }
            Console.WriteLine();
        }
    }
    static void multiplOfElementsInRowsWithoutNegNumbers(int[,] array)
    {
        bool[] isRowConsistNegativeNumber = new bool[array.GetLength(0)];
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (array[i, j] < 0)
                {
                    isRowConsistNegativeNumber[i] = true;
                    break;
                }
            }
        }
        for (int i = 0; i < array.GetLength(0); i++)
        {
            if (isRowConsistNegativeNumber[i] == true) continue;
            int dob = 1;
            for (int j = 0; j < array.GetLength(1); j++)
            {
                dob *= array[i, j];
            }
            Console.WriteLine("Product of elements in {0} row: {1}", i + 1, dob);
        }
    }
    static void maxSumOfParallelDiagToMainDiag(int[,] array, int N, int M) 
    {
        if (N == M)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            int maxSum = int.MinValue;
            for (int i = 0; i < rows; i++)
            {
                int sum = 0;
                int row = i;
                int col = 0;
                while (row < rows && col < cols)
                {
                    sum += array[row, col];
                    row++;
                    col++;
                }
                if (sum > maxSum)
                {
                    maxSum = sum;
                }
            }
            for (int j = 1; j < cols; j++)
            {
                int sum = 0;
                int row = 0;
                int col = j;
                while (row < rows && col < cols)
                {
                    sum += array[row, col];
                    row++;
                    col++;
                }
                if (sum > maxSum)
                {
                    maxSum = sum;
                }
            }
            Console.WriteLine("Maximum sum of elements from diagonals that parallel to main: {0}", maxSum);
        }
        else Console.WriteLine("This is not a square matrix");
    }
    static void sumOfElementsInColumnsWithoutNegEl(int[,] array)
    {
        bool[] isColumnConsistNegativeNumber = new bool[array.GetLength(1)];
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                if (array[i, j] < 0)
                {
                    isColumnConsistNegativeNumber[j] = true;
                    break;
                }
            }
        }
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (isColumnConsistNegativeNumber[j] == true) continue;
            int sum = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                sum += array[i, j];
            }
            Console.WriteLine("Sum of elements in {0} column: {1}", j + 1, sum);
        }
    }
    static void minSumOfAbsoluteElementsFromDiagParallelToSecondaryDiag(int[,] array, int N, int M) 
    {
        if (N == M)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            int minSum = int.MaxValue;
            for (int i = 0; i < rows; i++)
            {
                int sum = 0;
                int row = i;
                int col = cols - 1;
                while (row < rows && col >= 0)
                {
                    sum += Math.Abs(array[row, col]);
                    row++;
                    col--;
                }
                if (sum < minSum)
                {
                    minSum = sum;
                }
            }
            for (int j = cols - 2; j >= 0; j--)
            {
                int sum = 0;
                int row = 0;
                int col = j;
                while (col >= 0 && row < rows)
                {
                    sum += Math.Abs(array[row, col]);
                    row++;
                    col--;
                }
                if (sum < minSum)
                {
                    minSum = sum;
                }
            }
            Console.WriteLine("Minimal sum of absolute elements from diagonals that parallel to secondary diagonal: {0}", minSum);
        }
        else Console.WriteLine("This is not a square matrix");
    }
    static void sumOfElementsInColumnsWithNegEl(int[,] array)
    {
        bool[] isColumnConsistNegativeNumber = new bool[array.GetLength(1)];
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                if (array[i, j] < 0)
                {
                    isColumnConsistNegativeNumber[j] = true;
                    break;
                }
            }
        }
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (isColumnConsistNegativeNumber[j] == false) continue;
            int sum = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                sum += array[i, j];
            }
            Console.WriteLine("Sum of elements in {0} column: {1}", j + 1, sum);
        }
    }
    static void transposeMatrix(int[,] array)
    {
        int rows = array.GetLength(0);
        int cols = array.GetLength(1);
        int[,] transposed = new int[cols, rows];
        for (int i = 0; i < cols; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                transposed[i, j] = array[j, i];
            }
        }
        Console.WriteLine("Transposed matrix:");
        printArray(transposed);
    }
}