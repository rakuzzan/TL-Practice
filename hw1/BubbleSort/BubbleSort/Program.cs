using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    internal class Program
    {

        public static void Sort(List<int> lst)
        {
            for (int i = 0; i < lst.Count; i++)
            {
                for (int j = 0; j < lst.Count - 1; j++)
                {
                    if (lst[j].CompareTo(lst[j + 1]) > 0)
                    {
                        Swap(lst, j, j + 1);
                    }
                }
            }
        }

        private static void Swap(List<int> lst, int left, int right)
        {
            (lst[right], lst[left]) = (lst[left], lst[right]);
        }

        public static void PrintList(List<int> lst)
        {
            foreach (int el in lst)
            {
                Console.Write(el + " ");
            }
            Console.WriteLine();
        }

        public static void ReadList(List<int> lst)
        {
            Console.WriteLine("Введите строку чисел через пробел для сортировки:");

            string input = Console.ReadLine();
            string[] numbers = input.Split(' ');

            foreach (string number in numbers)
            {
                int parsedNumber = int.Parse(number);
                lst.Add(parsedNumber);
            }
        }

        static void Main(string[] args)
        {
            var numbers = new List<int>();

            ReadList(numbers);
            Sort(numbers);
            PrintList(numbers);
        }
    }
}
