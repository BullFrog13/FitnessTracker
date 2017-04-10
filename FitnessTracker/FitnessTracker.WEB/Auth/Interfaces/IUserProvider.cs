using System.Collections.Generic;
using FitnessTracker.WEB.ViewModels.AuthModels;

namespace FitnessTracker.WEB.Auth.Interfaces
{
    public interface IUserProvider
    {
        User User { get; set; }

        IEnumerable<string> Roles();
    }
}