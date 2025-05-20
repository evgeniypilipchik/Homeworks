namespace Homework_12
{
    internal class WrongLoginException : Exception
    {
        public WrongLoginException() : base(String.Empty) { }

        public WrongLoginException(string message) : base(message) { }
    }
}