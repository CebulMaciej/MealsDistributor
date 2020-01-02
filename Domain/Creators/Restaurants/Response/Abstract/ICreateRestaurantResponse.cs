using System;
using System.Collections.Generic;
using System.Text;
using Domain.BusinessObject;
using Domain.Creators.Restaurants.Response.Const;

namespace Domain.Creators.Restaurants.Response.Abstract
{
    public interface ICreateRestaurantResponse
    {
        Restaurant Restaurant { get; }
        CreateRestaurantEnum Result { get; }
    }
}
