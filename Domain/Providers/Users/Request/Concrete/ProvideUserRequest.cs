using System;
using System.Collections.Generic;
using System.Text;
using Domain.Providers.Users.Request.Abstract;

namespace Domain.Providers.Users.Request.Concrete
{
    public class ProvideUserRequest : IProvideUserRequest
    {
        public ProvideUserRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
