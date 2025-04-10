﻿using System.Text;

namespace Homework_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string lowerCase = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            var lowerCaseArray = lowerCase.ToArray();
            string upperCase = lowerCase.ToUpper();
            var upperCaseArray = upperCase.ToArray();

            string task = "";

            while (task != "1" && task != "2")
            {
                Console.WriteLine("В случае шифровки сообщения введите \"1\"\nВ случае расшифровки сообщения введите \"2\"");
                task = Console.ReadLine();
            }

            string number;
            bool result = false;
            int key = 0;

            while (result == false) 
            {
                Console.WriteLine("Введите ключ шифрования\n(число, на сколько символов сдвигать буквы)");
                number = Console.ReadLine();
                result = int.TryParse(number, out key);
            }

            key = (task == "2") ? key * -1 : key;

            Console.WriteLine("Введите сообщение русскими буквами");
            string message = Console.ReadLine();
            StringBuilder changingMessage = new StringBuilder(message);

            for (int i = 0; message.Length > i; i++)
            {
                bool isLetter = Char.IsLetter(message, i);

                if (!isLetter)
                {
                    continue;
                }
                int lowerIndexInAlphabet = Array.IndexOf(lowerCaseArray, message[i]);
                int upperIndexInAlphabet = Array.IndexOf(upperCaseArray, message[i]);
                char criptedLetter;
                int criptedIndex;

                if (lowerIndexInAlphabet != -1)
                {

                    if (key >= 0)
                    {
                        criptedIndex = (lowerIndexInAlphabet + key) % lowerCaseArray.Length;
                    }
                    else
                    {
                        criptedIndex = (lowerIndexInAlphabet + key) >= 0 ? (lowerIndexInAlphabet + key) % (lowerCaseArray.Length - 1) : (lowerCaseArray.Length) + lowerIndexInAlphabet + key;
                    }
                    criptedLetter = lowerCaseArray[criptedIndex];

                }
                else if (upperIndexInAlphabet != -1)
                {

                    if (key >= 0)
                    {
                        criptedIndex = (upperIndexInAlphabet + key) % upperCaseArray.Length;
                    }
                    else
                    {
                        criptedIndex = (upperIndexInAlphabet + key) >= 0 ? (upperIndexInAlphabet + key) % (upperCaseArray.Length - 1) : (upperCaseArray.Length) + upperIndexInAlphabet + key;
                    }
                    criptedLetter = upperCaseArray[criptedIndex];

                }
                else
                {
                    continue;
                }

                changingMessage[i] = criptedLetter;
            }

            Console.WriteLine(changingMessage);
        }
    }
}
