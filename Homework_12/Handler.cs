using System.Text.RegularExpressions;

namespace Homework_12
{
    public class Handler
    {
        public static bool InputHandler(string login, string password, string confirmPassword)
        {

            if (login.Contains(" "))
            {
                throw new WrongLoginException("Логин не должен содержать пробелы");
            }

            if (login.Length == 0 || login.Length > 20)
            {
                throw new WrongLoginException("Логин не должен содержать более двадцати символов");
            }

            if (password.Contains(" "))
            {
                throw new WrongPasswordException("Пароль не должен содержать пробелы");
            }

            if (password.Length == 0 || password.Length > 20)
            {
                throw new WrongPasswordException("Пароль не должен содержать более двадцати символов");
            }

            if (!Regex.IsMatch(password, @"\d"))
            {
                throw new WrongPasswordException("Пароль должен содержать хотя бы одну цифру");
            }

            if (confirmPassword != password)
            { 
                throw new WrongPasswordException("Подтверждённый пароль не совпадает с паролем");
            }

            return true;
        }
    }
}
