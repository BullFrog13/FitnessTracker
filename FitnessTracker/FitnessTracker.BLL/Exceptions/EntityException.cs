using System;

namespace FitnessTracker.BLL.Exceptions
{
    public class EntityException : Exception
    {
        public EntityException(string message, string entity) : base(message)
        {
            Entity = entity;
        }

        public string Entity { get; }
    }
}
