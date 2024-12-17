using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            var secretNumber = GenerateNumber(rand);

            Console.WriteLine("Попробуйте угадать заданное число");

            while (true)
            {
                Console.Write("Введите ваше число: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int guess) && guess >= 1000 && guess <= 9999)
                {
                    var result = CompareNumbers(secretNumber, guess);
                    Console.WriteLine(result);

                    if (result == "Поздравляем Вы угадали число.")
                    {
                        break;
                    }
                }

                else
                {
                    Console.WriteLine("Некорректный ввод. Введите четырёхзначное число.");
                }
            }
        }

        static int GenerateNumber(Random rand)
        {
            while (true)
            {
                int number = rand.Next(1000, 10000);
                var digits = number.ToString().ToCharArray();
                if (IsUnique(digits))
                {
                    return number;
                }
            }
        }

        static bool IsUnique(char[] digits)
        {
            for (int i = 0; i < digits.Length; i++)
            {
                for (int j = i + 1; j < digits.Length; j++)
                {
                    if (digits[i] == digits[j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        static string CompareNumbers(int secret, int guess)
        {
            var specifNumb = secret.ToString().ToCharArray();
            var guessDigits = guess.ToString().ToCharArray();
            int trueNumb = 0;
            int falseNumb = 0;

            for (int i = 0; i < 4; i++)
            {
                if (specifNumb[i] == guessDigits[i])
                {
                    trueNumb++;
                }
                else if (Array.IndexOf(specifNumb, guessDigits[i]) != -1)
                {
                    falseNumb++;
                }
            }

            if (trueNumb == 4)
            {
                return "Поздравляем Вы угадали число.";
            }
            else
            {
                return $"цифры на правильных позициях: {trueNumb}, цифры в числе, но не на правильных позициях: {falseNumb}";
            }
        }
    }
}


