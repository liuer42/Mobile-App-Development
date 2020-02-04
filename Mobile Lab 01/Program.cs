using System;
using System.Collections.Generic;
using System.Linq;

namespace Mobile_Lab_01
{
    class Program
    {
        private static List<List<int>> numLists;
        private static int gridInput;
        private static int flipInput;

        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Enter a number between 3 and 9:");
                gridInput = Convert.ToInt32(Console.ReadLine());
                if (gridInput < 10 && gridInput > 2)
                {
                    MakeGrid();
                    PrintGrid();
                    TransformMenu();
                }
            } while (gridInput > 9 || gridInput < 3);
        }

        private static void FlipHorizontal()
        {
            foreach (var row in numLists)
            {
                if (row.First() < row.Last())
                    row.Sort((x, y) => y.CompareTo(x));
                else
                    row.Sort((x, y) => x.CompareTo(y));
            }
        }

        private static void FlipVertical()
        {
            if (numLists.First().First() < numLists.Last().First())
                numLists.Sort((x, y) => y.First().CompareTo(x.First()));
            else
                numLists.Sort((x, y) => x.First().CompareTo(y.First()));
        }

        private static void MakeGrid()
        {
            numLists = new List<List<int>>();

            if (gridInput > 3 && gridInput < 9)
            {
                for (int i = 1; i <= gridInput; i++)
                {
                    var row = new List<int>();
                    for (int j = 1; j <= gridInput; j++)
                    {
                        row.Add(i * j);
                    }
                    numLists.Add(row);
                }
            }
        }

        public static void PrintGrid()
        {
            foreach (var row in numLists)
            {
                foreach (var num in row)
                {
                    Console.Write($"{num}\t");
                }
                Console.WriteLine(" ");
            }
            Console.WriteLine();
        }

        private static void TransformMenu()
        {
            while (true)
            {
                Console.WriteLine("\nFlip on " +
                                  "\n1) Horizon" +
                                  "\n2) Vertical" +
                                  "\n3) Diagonal Left" +
                                  "\n4) Diagonal Right" +
                                  "\n5) End");
                flipInput = Convert.ToInt32(Console.ReadLine());
                if (flipInput > 0 && flipInput < 6)
                {
                    switch (flipInput)
                    {
                        case 1:
                            FlipHorizontal();
                            PrintGrid();
                            break;
                        case 2:
                            FlipVertical();
                            PrintGrid();
                            break;
                        case 3:
                            FlipVertical();
                            FlipHorizontal();
                            PrintGrid();
                            break;
                        case 4:
                            FlipHorizontal();
                            FlipVertical();
                            PrintGrid();
                            break;
                        case 5:
                            return;
                    }
                }
            }
        }
    }
}
