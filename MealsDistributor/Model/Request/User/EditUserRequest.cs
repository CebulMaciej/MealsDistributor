using System;

namespace MealsDistributor.Model.Request.User
{
    public class EditUserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsValid => !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password);
    }
}
