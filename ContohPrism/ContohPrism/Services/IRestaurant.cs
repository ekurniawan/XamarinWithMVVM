using ContohPrism.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContohPrism.Services
{
    public interface IRestaurant
    {
        Task<List<Restaurant>> GetAllRestaurant();
        Task InsertRestaurant(Restaurant restaurant);
        Task UpdateRestaurant(Restaurant restaurant);
        Task DeleteRestaurant(int restaurantid);
    }
}
