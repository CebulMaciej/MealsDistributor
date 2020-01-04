using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealsDistributor.Model.ApiModels;

namespace MealsDistributor.Model.Request.User
{
    public class AddUserRequest 
    {
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public string Email { get; set; }
        public int Role { get; set; }
        public bool IsValid => !string.IsNullOrWhiteSpace(Password) &&
                               !string.IsNullOrWhiteSpace(ConfirmPassword) &&
                               Password.Equals(ConfirmPassword) &&
                               !string.IsNullOrWhiteSpace(Email);
    }
}
