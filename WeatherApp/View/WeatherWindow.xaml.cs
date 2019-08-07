/***************************
 *   Ed Friesema     7/2/2019
 *   Project Weather App 
 *   Accuweather.cs
 *   Design Pattern MVVM - View
 *   Purpose:  Basic C# initialization.  Project attempted to use 
 *   Property BInding and ICommand interface to minimize code behind
 *   

 * *************************/
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WeatherApp.ViewModel;

namespace WeatherApp.View
{
    /// <summary>
    /// Interaction logic for WeatherWindow.xaml
    /// </summary>
    public partial class WeatherWindow : Window
    {
        public WeatherWindow()
        {
            InitializeComponent();

        }
    }
        
}
