using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MealsDistributor.Infrastructure.IdFromClaimsExpanding.Abstract;

namespace MealsDistributor.Infrastructure.IdFromClaimsExpanding.Concrete
{
    public class UserIdFromClaimsExpander : IUserIdFromClaimsExpander
    {
        public Guid ExpandIdFromClaims(ClaimsPrincipal claimsPrincipal)
        {
            return Guid.Parse(claimsPrincipal.Claims.First(x=> x.Type == "Id").Value);
        }
    }
}
