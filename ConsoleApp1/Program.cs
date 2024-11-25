using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Welcome to the Sorting Application!");

        // Solicitar al usuario 10 números diferentes
        while (numbers.Count < 10)
        {
            try
            {
                Console.Write($"Enter number {numbers.Count + 1}: ");
                int input = int.Parse(Console.ReadLine());

                if (numbers.Contains(input))
                {
                    Console.WriteLine("Error: Duplicate numbers are not allowed. Try again.");
                }
                else
                {
                    numbers.Add(input);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter a valid integer.");
            }
        }

        // Mostrar menú de ordenamiento
        Console.WriteLine("\nChoose a sorting method:");
        Console.WriteLine("1. Bubble Sort");
        Console.WriteLine("2. Shell Sort");
        Console.WriteLine("3. Selection Sort");
        Console.WriteLine("4. Insertion Sort");
        Console.Write("Your choice: ");
        int choice = int.Parse(Console.ReadLine());

        List<int> sortedNumbers = new List<int>();

        // Aplicar el método de ordenamiento seleccionado
        switch (choice)
        {
            case 1:
                sortedNumbers = BubbleSort(numbers);
                Console.WriteLine("Numbers sorted using Bubble Sort.");
                break;
            case 2:
                sortedNumbers = ShellSort(numbers);
                Console.WriteLine("Numbers sorted using Shell Sort.");
                break;
            case 3:
                sortedNumbers = SelectionSort(numbers);
                Console.WriteLine("Numbers sorted using Selection Sort.");
                break;
            case 4:
                sortedNumbers = InsertionSort(numbers);
                Console.WriteLine("Numbers sorted using Insertion Sort.");
                break;
            default:
                Console.WriteLine("Invalid choice. Exiting program.");
                return;
        }

        // Mostrar y guardar los números ordenados
        Console.WriteLine("\nSorted numbers:");
        foreach (var num in sortedNumbers)
        {
            Console.Write(num + " ");
        }

        Console.WriteLine("\nSaving results to 'sorted_numbers.txt'...");
        File.WriteAllLines("sorted_numbers.txt", sortedNumbers.ConvertAll(x => x.ToString()));
        Console.WriteLine("Results saved successfully.");
    }

    // Bubble Sort
    static List<int> BubbleSort(List<int> numbers)
    {

        List<int> list = new List<int>(numbers);
        Console.WriteLine("count", list.Count - 1);
        for (int i = 0; i < list.Count - 1; i++)
        {
            for (int j = 0; j < list.Count - i - 1; j++)
            {
                if (list[j] > list[j + 1])
                {
                    int temp = list[j];
                    list[j] = list[j + 1];
                    list[j + 1] = temp;
                }
            }
        }
        return list;
    }

    // Shell Sort
    static List<int> ShellSort(List<int> numbers)
    {
        List<int> list = new List<int>(numbers);
        int gap = list.Count / 2;
        while (gap > 0)
        {
            for (int i = gap; i < list.Count; i++)
            {
                int temp = list[i];
                int j = i;
                while (j >= gap && list[j - gap] > temp)
                {
                    list[j] = list[j - gap];
                    j -= gap;
                }
                list[j] = temp;
            }
            gap /= 2;
        }
        return list;
    }

    // Selection Sort
    static List<int> SelectionSort(List<int> numbers)
    {
        List<int> list = new List<int>(numbers);
        for (int i = 0; i < list.Count - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < list.Count; j++)
            {
                if (list[j] < list[minIndex])
                {
                    minIndex = j;
                }
            }
            int temp = list[minIndex];
            list[minIndex] = list[i];
            list[i] = temp;
        }
        return list;
    }

    // Insertion Sort
    static List<int> InsertionSort(List<int> numbers)
    {
        List<int> list = new List<int>(numbers);
        for (int i = 1; i < list.Count; i++)
        {
            int key = list[i];
            int j = i - 1;
            while (j >= 0 && list[j] > key)
            {
                list[j + 1] = list[j];
                j--;
            }
            list[j + 1] = key;
        }
        return list;
    }
}
