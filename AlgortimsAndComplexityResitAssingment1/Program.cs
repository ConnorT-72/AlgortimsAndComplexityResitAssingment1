using System;
using System.IO;

namespace ConsoleArrayOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] share1Array = ReadArrayFromFile("Share_1_256.txt");
            int[] share2Array = ReadArrayFromFile("Share_2_256.txt");
            int[] share3Array = ReadArrayFromFile("Share_3_256.txt");

            Console.WriteLine("Share 1 Array:");
            DisplayArray(share1Array);

            Console.WriteLine("Share 2 Array:");
            DisplayArray(share2Array);

            Console.WriteLine("Share 3 Array:");
            DisplayArray(share3Array);

            SortAndDisplayEveryNthValue(share1Array, 10);
            SortAndDisplayEveryNthValue(share2Array, 10);
            SortAndDisplayEveryNthValue(share3Array, 10);

            SearchAndDisplayLocations(share1Array);
            SearchAndDisplayLocations(share2Array);
            SearchAndDisplayLocations(share3Array);

            SearchAndDisplayNearest(share1Array);
            SearchAndDisplayNearest(share2Array);
            SearchAndDisplayNearest(share3Array);

            Console.ReadLine();
        }

        static int[] ReadArrayFromFile(string fileName)
        {
            string filePath = fileName;
            string[] lines = System.IO.File.ReadAllLines(filePath);
            int[] array = new int[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                array[i] = int.Parse(lines[i]);
            }
            return array;
        }

        static void DisplayArray(int[] array)
        {
            foreach (int num in array)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();
        }

        static void SortAndDisplayEveryNthValue(int[] array, int n)
        {
            Array.Sort(array);

            Console.WriteLine("Array sorted in ascending order:");
            DisplayEveryNthValue(array, n);

            Array.Reverse(array);

            Console.WriteLine("Array sorted in descending order:");
            DisplayEveryNthValue(array, n);
        }

        static void DisplayEveryNthValue(int[] array, int n)
        {
            for (int i = 0; i < array.Length; i += n)
            {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();
        }

        static void SearchAndDisplayLocations(int[] array)
        {
            Console.Write("Enter a value to search for: ");
            int searchValue = int.Parse(Console.ReadLine());

            bool found = false;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == searchValue)
                {
                    Console.WriteLine($"Value {searchValue} found at index {i}");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine($"Value {searchValue} not found.");
            }
        }

        static void SearchAndDisplayNearest(int[] array)
        {
            Console.Write("Enter a value to search for its nearest: ");
            int nearestValue = int.Parse(Console.ReadLine());

            int nearestDifference = int.MaxValue;
            int nearestIndex = -1;

            for (int i = 0; i < array.Length; i++)
            {
                int difference = Math.Abs(array[i] - nearestValue);
                if (difference < nearestDifference)
                {
                    nearestDifference = difference;
                    nearestIndex = i;
                }
            }

            Console.WriteLine($"Nearest value to {nearestValue} is {array[nearestIndex]} at index {nearestIndex}");
        }
    }
}
