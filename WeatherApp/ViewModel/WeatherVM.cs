/***************************
 *   Ed Friesema     7/2/2019
 *   Project Weather App 
 *   Accuweather.cs
 *   Design Pattern MVVM - ViewModel
 *   Purpose: To implment the Weather View Model with necessary classes 
 *   and methods to get appropriate information when Query and SelectedResult 
 *   are changed by the user
 *   

 * *************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;
using System.ComponentModel;
using System.Collections.ObjectModel;
using WeatherApp.ViewModel.Commands;

namespace WeatherApp.ViewModel
{
    public class WeatherVM
    {
        public AccuWeather Weather { get; set; }

        public ObservableCollection<City> Cities { get; set; }

        public ObservableCollection<DailyForecast> Forecasts { get; set; }

        private City selectedResult;
        public City SelectedResult
        {
            get { return selectedResult; }
            set
            {
                selectedResult = value;
                GetWeather();      //Get Forecast list from API 
            }
        }

        public RefreshCommand RefreshCommand { get; set; }

        private string query;
        public string Query
        {
            get { return query; }
            set {
                query = value;
                GetCities(query);     //Get Cities Cities List from API
            }
        }
   
        public WeatherVM()   // Constructor initializes all ViewModel attributes
        {
            AccuWeather Weather = new AccuWeather();
            Forecasts = new ObservableCollection<DailyForecast>();
            Cities = new ObservableCollection<City>();
            SelectedResult = new City();
            RefreshCommand = new RefreshCommand(this);  // WeatherVM must be passed to RefreschCommand so that it doesn't try 
                                                        // to create a new ViewModel every time Refresh button is clicked
        }

        private async void GetCities(string Query)      // Build List of Cities from AutoComplet API call
        {
            Cities.Clear();
            var cities = await WeatherAPI.GetAutocompleteAsync(Query);   //
            foreach (var city in cities)
            {
                Cities.Add(city);
            }
        }

        public async void GetWeather()      //Build list of Forecats from API
        {
            Forecasts.Clear();
            if (SelectedResult != null)
            {
                var weather = await WeatherAPI.GetWeatherInformationAsync(SelectedResult.Key);

                if (weather.DailyForecasts != null)
                {
                    foreach (var forecast in weather.DailyForecasts)
                    {
                        Forecasts.Add(forecast);
                    }

                    //TODO: implement radio button to convert forecast values from C to F
                }
            }

        }
        
    }
}
