namespace FitnessTracker.DAL.Entities
{
    public class User : BaseType
    {
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }
    }
}