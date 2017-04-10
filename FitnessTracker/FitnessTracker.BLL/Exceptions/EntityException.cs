using System;

namespace FitnessTracker.BLL.Exceptions
{
    public class EntityException : Exception
    {
        protected EntityException(string message, string entity) : base(message)
        {
            Entity = entity;
        }

        private string Entity { get; }
    }
}