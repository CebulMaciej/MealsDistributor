using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MealsDistributor.Infrastructure.IdFromClaimsExpanding.Abstract
{
    public interface IUserIdFromClaimsExpander
    {
        Guid ExpandIdFromClaims(ClaimsPrincipal claimsPrincipal);
    }
}
