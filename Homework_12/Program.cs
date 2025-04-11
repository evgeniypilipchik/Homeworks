namespace Homework_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(
                    "Логин не должен содержать пробелы.\n" +
                    "Логин не должен содержать более двадцати символов\n" +
                    "Введите логин:\n");

                string login = Console.ReadLine();

                Console.WriteLine("\n" +
                    "Пароль не должен содержать пробелы.\n" +
                    "Пароль не должен содержать более двадцати символов\n" +
                    "пароль должен содержать хотя бы одну цифру\n" +
                    "Введите пароль:\n");

                string password = Console.ReadLine();

                Console.WriteLine("\nПодтвердите пароль\n");

                string confirmPassword = Console.ReadLine();

                bool inputData = Handler.InputHandler(login, password, confirmPassword);
            }
            catch (WrongLoginException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (WrongPasswordException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
