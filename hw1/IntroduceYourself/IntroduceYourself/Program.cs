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
        private static bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        private static bool IsValidGitHubLink(string link)
        {
            string pattern = @"^(https?)://(www\.)?github\.com/.*$";
            return Regex.IsMatch(link, pattern);
        }


        private static bool IsValidFullName(string fullName)
        {
            string pattern = @"^[А-ЯЁ][а-яё]+ [А-ЯЁ][а-яё]+ [А-ЯЁ][а-яё]+$";
            return Regex.IsMatch(fullName, pattern);
        }

        private static string ReadFullName()
        {
            Console.WriteLine($"Введите Ф.И.О.: ");
            string fullName = Console.ReadLine();
            if (!(IsValidFullName(fullName)))
            {
                Console.WriteLine("Вы неверно ввели свое Ф.И.О. Ф.И.О должно содержать только буквы без посторонних символов");
                fullName = "-";
            }
            return fullName;
        }

        private static int ReadAge()
        {
            Console.WriteLine("Введите ваш возраст: ");
            string ageString = Console.ReadLine();
            bool isValidAge = int.TryParse(ageString, out int outAge);

            int age = outAge;

            if (!(isValidAge && age > 0))
            {
                Console.WriteLine("Вы неверно ввели возраст. Возраст должен содержать только цифры без посторонних символов");
                age = 0;
            }

            return age;
        }

        private static string ReadEmail()
        {
            Console.WriteLine("Введите ваш e-mail: ");
            string email = Console.ReadLine();

            if (!IsValidEmail(email))
            {
                Console.WriteLine("Вы ввели неправильный e-mail.");
                email = "-";
            }
            return email;
        }

        private static string ReadGitHubLink()
        {
            Console.WriteLine($"Введите ссылку на ваш GitHub.: ");
            string url = Console.ReadLine();

            if (!IsValidGitHubLink(url))
            {
                Console.WriteLine("Вы ввели невалидную ссылку.");
                url = "https://github.com";
            }

            return url;
        }

        private static void Main(string[] args)
        {

            string fullName = ReadFullName();
            int age = ReadAge();
            string email = ReadEmail();
            string url = ReadGitHubLink();

            Console.WriteLine($"Ваши данные:\n" +
                $"Ф.И.О.\t{fullName}\n" +
                $"Возраст\t{age}\n" +
                $"e-mail\t{email}\n" +
                $"url\t{url}\n");
        }
    }
}
