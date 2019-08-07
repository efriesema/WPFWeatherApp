/***************************
 *   Ed Friesema     7/2/2019
 *   Project Weather App 
 *   WeatherAPI.cs
 *   Design Pattern MVVM - ViewModel
 *   Purpose: To implement the API calls to Accuweather for Autocomplete 
 *   5-day forecast and to take JSOn object and import it into appropriate
 *   Object Data strcuture
 *   
 * *************************/

using Newtonsoft.Json;       //Used to Deserialize JSON objects from request call
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;

namespace WeatherApp.ViewModel
{
    public class WeatherAPI
    {
        public const string API_KEY = "cmy7Cqum8kJUpB6b0vU4BmZdrSJqNKEV";
        public const string BASE_URL = "http://dataservice.accuweather.com/forecasts/v1/daily/5day/{0}?apikey={1}&metric=true";
        public const string BASE_URL_AUTOCOMPLETE = "http://dataservice.accuweather.com/locations/v1/cities/autocomplete?apikey={0}&q={1}";

        public static async Task<List<City>> GetAutocompleteAsync(string query)
        {
            List<City> result= new List<City>();
            string url = string.Format(BASE_URL_AUTOCOMPLETE, API_KEY, query);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<City>>(json);
            }

            return result;
        } 

        public static async Task<AccuWeather> GetWeatherInformationAsync(string locationKey)
        {
            AccuWeather result = new AccuWeather();

            string url = string.Format(BASE_URL, locationKey, API_KEY);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                result = JsonConvert.DeserializeObject<AccuWeather>(json);
            }

            return result;
        }
    }
}
