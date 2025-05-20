namespace Homework_12
{
    internal class WrongPasswordException : Exception
    {
        public WrongPasswordException() : base(String.Empty) { }

        public WrongPasswordException(string message) : base(message) { }
    }
}