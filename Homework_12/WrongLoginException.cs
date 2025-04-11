namespace Homework_12
{
    internal class WrongLoginException : Exception
    {
        public WrongLoginException(string message) : base(message) { }
    }
}