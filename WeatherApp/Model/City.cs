/***************************
 *   Ed Friesema     7/2/2019
 *   Project Weather App 
 *   City.cs
 *   Design Pattern MVVM - Model
 *   Purpose: To create a Data Object to Display the Accuweather API 
 *   Location Autocomplete city data,  And also to incorporate the 
 *   INotifyPropertyChanged Interface to keep the interface updated
 *   

 * *************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Model
{
    public class Area: INotifyPropertyChanged                //Interface to notify View that certian Property's have changed 
                                                             //and to update Xaml Bindings and possibly run API calls
    {
        private string id;
        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        private string localizedName;
        public string LocalizedName
        {
            get { return localizedName; }
            set
            {
                localizedName = value;
                OnPropertyChanged("LocalizedName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));      // this format checks if PropertyChanged != null 
                                                                                            // before creating the new PropertyChangedArgs
        }
    }


    public class City:INotifyPropertyChanged
    {
        //public int Version { get; set; }
        private string key;
        public string Key
        {
            get { return key; }
            set
            {
                key = value;
                OnPropertyChanged("Key");
            }
        }
        //public string Type { get; set; }
        //public int Rank { get; set; }
        private string localizedName;
        public string LocalizedName
        {
            get { return localizedName;  }
            set
            {
                localizedName = value;
                OnPropertyChanged("LocalizedName");
            }
        }
        private Area country;
        public Area Country
        {
            get { return country; }
            set
            {
                country = value;
                OnPropertyChanged("Country");
            }
        }
        private Area administrativeArea;
        public Area AdministrativeArea
        {
            get { return administrativeArea; }
            set
            {
                administrativeArea = value;
                OnPropertyChanged("AdministrativeArea");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

    
