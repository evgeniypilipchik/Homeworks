namespace Homework_12
{
    internal class WrongPasswordException : Exception
    {
        public WrongPasswordException(string message) : base(message) { }
    }
}