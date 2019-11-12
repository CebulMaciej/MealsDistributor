using System;

namespace MealsDistributor.Model.ApiModels
{
    public class UserApiModel
    {
        public Guid? Id { get; set; }
        public string Email { get; set; }
        public DateTime CreationDate { get; set; }
        public int Role { get; set; }
    }
}
