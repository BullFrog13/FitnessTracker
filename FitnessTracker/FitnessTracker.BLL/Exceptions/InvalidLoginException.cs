using System;

namespace FitnessTracker.BLL.Exceptions
{
    public class InvalidLoginException : Exception
    {
        public InvalidLoginException(string message, string login) : base(message)
        {
            Login = login;
        }

        private string Login { get; }
    }
}