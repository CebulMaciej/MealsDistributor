using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealsDistributor.Model.Request.User
{
    public class LoginRequestModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
