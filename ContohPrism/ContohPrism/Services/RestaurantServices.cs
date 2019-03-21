using ContohPrism.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ContohPrism.Services
{
    public class RestaurantServices : IRestaurant
    {
        private HttpClient _client;
        public RestaurantServices()
        {
            _client = new HttpClient();
        }
        private string GetServiceUrl()
        {
            return "http://168.63.236.219/";
        }

        public async Task<List<Restaurant>> GetAllRestaurant()
        {
            List<Restaurant> lstResto = new List<Restaurant>();

            var uri = new Uri(GetServiceUrl() + "api/Restaurant");
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    lstResto = JsonConvert.DeserializeObject<List<Restaurant>>(content);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
            return lstResto;
        }


        public async Task InsertRestaurant(Restaurant restaurant)
        {
            var uriPost = new Uri(GetServiceUrl() + "api/Restaurant");
            
            try
            {
                var jsonData = JsonConvert.SerializeObject(restaurant);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync(uriPost, content);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Gagal menambahkan data");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateRestaurant(Restaurant restaurant)
        {
            var uriUpdate = new Uri(GetServiceUrl() + "api/Restaurant");

            try
            {
                var jsonData = JsonConvert.SerializeObject(restaurant);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = await _client.PutAsync(uriUpdate, content);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Gagal mengupdate data");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteRestaurant(int restaurantid)
        {
            var uriDelete = new Uri(GetServiceUrl() + $"api/Restaurant/{restaurantid}");
            try
            {
                var response = await _client.DeleteAsync(uriDelete);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Gagal untuk mendelete data");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
