/***************************
 *   Ed Friesema     7/2/2019
 *   Project Weather App 
 *   Accuweather.cs
 *   Design Pattern MVVM - Model
 *   Purpose: To create a Data Object to Display the Accuweather API 
 *   Forecast data,  And also to incorporate the INotifyPropertyChanged 
 *   Interface,  so that as Forecast information is updated the display 
 *   is also updated
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

    public class Range : INotifyPropertyChanged         //Interface to notify View that certian Property's have changed 
                                                        //and to update Xaml Bindings and possibly run API calls
    {
        private double value;

        public double Value
        {
            get { return value; }
            set
            {
                this.value = value;
                OnPropertyChanged("Value");
            }
        }

        private string unit;

        public string Unit
        {
            get { return unit; }
            set
            {
                unit = value;
                OnPropertyChanged("Unit");
            }
        }

        private int unitType;

        public int UnitType
        {
            get { return unitType; }
            set
            {
                unitType = value;
                OnPropertyChanged("UnitType");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));  // this format checks if PropertyChanged != null 
                                                                                        // before creating the new PropertyChangedArgs
        }
    }

    public class Temperature : INotifyPropertyChanged
    {
        private Range minimum;

        public Range Minimum
        {
            get { return minimum; }
            set
            {
                minimum = value;
                OnPropertyChanged("Minimum");
            }
        }

        private Range maximum;

        public Range Maximum
        {
            get { return maximum; }
            set
            {
                maximum = value;
                OnPropertyChanged("Maximum");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class TimeOfDay : INotifyPropertyChanged
    {
        private int icon;

        public int Icon
        {
            get { return icon; }
            set
            {
                icon = value;
                OnPropertyChanged("Icon");
            }
        }

        private string iconPhrase;

        public string IconPhrase
        {
            get { return iconPhrase; }
            set
            {
                iconPhrase = value;
                OnPropertyChanged("IconPhrase");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class DailyForecast : INotifyPropertyChanged
    {
        public List<string> Sources { get; set; }

        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }

        private Temperature temperature;

        public Temperature Temperature
        {
            get { return temperature; }
            set
            {
                temperature = value;
                OnPropertyChanged("Temperature");
            }
        }

        private TimeOfDay day;

        public TimeOfDay Day
        {
            get { return day; }
            set
            {
                day = value;
                OnPropertyChanged("Day");
            }
        }

        private TimeOfDay night;

        public TimeOfDay Night
        {
            get { return night; }
            set
            {
                night = value;
                OnPropertyChanged("Night");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class AccuWeather
    {
        public List<DailyForecast> DailyForecasts { get; set; }

        public AccuWeather()
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))        // Allows default values to be pased while in Design mode 
                                                                                                       //that will not pass when running progam
            {
                DailyForecasts = new List<DailyForecast>();
                for (int i = 0; i < 3; i++)
                {
                    DailyForecast dailyForecast = new DailyForecast
                    {
                        Date = DateTime.Now.AddDays(-i),
                        Temperature = new Temperature
                        {
                            Maximum = new Range
                            {
                                Value = 21 + i
                            },
                            Minimum = new Range
                            {
                                Value = 5 - i
                            }
                        },
                        Day = new TimeOfDay
                        {
                            Icon =0,
                            IconPhrase ="partly sunny"
                        }
                    };
                    DailyForecasts.Add(dailyForecast);
                }
            }
        }
    }
}
