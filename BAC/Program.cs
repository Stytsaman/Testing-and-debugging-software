using BAC;
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
            Console.WriteLine("1. Регистрация" +
            "\n2. Авторизация (вход)" +
            "\nЕсли вы играете впервые нажмите 1 " +
            "\nЕсли вы уже играли нажмите 2 ");

            string _menuChoise = Console.ReadLine();

            switch (_menuChoise)
            {
                case "1":
                    User.Register();
                    break;

                    case "2":
                    User.Login();
                    break;

                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }


            var _randNumber = new Random();
            var _secretNumber = GenerateNumber(_randNumber);

            Console.WriteLine("Попробуйте угадать заданное число");

            while (true)
            {
                Console.Write("Введите ваше число: ");
                string _inputNumber = Console.ReadLine();

                if (int.TryParse(_inputNumber, out int guess) && guess >= 1000 && guess <= 9999)
                {
                    var _resultNumber = CompareNumbers(_secretNumber, guess);
                    Console.WriteLine(_resultNumber);

                    if (_resultNumber == "Поздравляем Вы угадали число.")
                    {
                        break;
                    }
                }

                else
                {
                    Console.WriteLine("Некорректный ввод. Введите четырёхзначное число.");
                }
            }
            Console.ReadLine();
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


