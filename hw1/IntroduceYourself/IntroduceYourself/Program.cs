using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IntroduceYourself
{
    internal class Program
    {
        public static bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        public static bool IsValidGitHubLink(string link)
        {
            string pattern = @"^https:\/\/github\.com\/.*$";
            return Regex.IsMatch(link, pattern);
        }


        public static bool IsValidFullName(string fullName)
        {
            string pattern = @"^[А-ЯЁ][а-яё]+ [А-ЯЁ][а-яё]+ [А-ЯЁ][а-яё]+$";
            return Regex.IsMatch(fullName, pattern);
        }

        static void Main(string[] args)
        {

            Console.WriteLine($"Введите Ф.И.О.: ");
            string fullName = Console.ReadLine();
            if (!(IsValidFullName(fullName)))
            {
                Console.WriteLine("Вы неверно ввели свое Ф.И.О. Ф.И.О должно содержать только буквы без посторонних символов");
                fullName = "-";
            }

            Console.WriteLine("Введите ваш возраст: ");
            string ageInString = Console.ReadLine();
            var isValidAge = int.TryParse(ageInString, out int age);

            if (!(isValidAge && age > 0))
            {
                Console.WriteLine("Вы неверно ввели возраст. Возраст должен содержать только цифры без посторонних символов");
                age = 0;
            }

            Console.WriteLine("Введите ваш e-mail: ");
            string email = Console.ReadLine();

            if (!IsValidEmail(email))
            {
                Console.WriteLine("Вы ввели неправильный e-mail.");
                email = "-";
            }

            Console.WriteLine($"Введите ссылку на ваш GitHub.: ");
            string url = Console.ReadLine();

            if (!IsValidGitHubLink(url))
            {
                Console.WriteLine("Вы ввели невалидную ссылку.");
                url = "https://github.com";
            }

            Console.WriteLine($"Ваши данные:\n" +
                $"Ф.И.О.\t{fullName}\n" +
                $"Возраст\t{age}\n" +
                $"e-mail\t{email}\n" +
                $"url\t{url}\n");
                
        }
    }
}
