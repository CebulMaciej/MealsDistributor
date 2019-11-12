using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealsDistributor.Model.ApiModels;

namespace MealsDistributor.Model.Request.User
{
    public class AddUserRequest : UserApiModel
    {
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public bool IsValid => !string.IsNullOrWhiteSpace(Password) &&
                               !string.IsNullOrWhiteSpace(ConfirmPassword) &&
                               Password.Equals(ConfirmPassword) &&
                               !string.IsNullOrWhiteSpace(Email);
    }
}
