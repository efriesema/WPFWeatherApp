/***************************
 *   Ed Friesema     7/2/2019
 *   Project Weather App 
 *   RefreshCammand.cs
 *   Design Pattern MVVM - View Model
 *   Purpose: to implement ICommand interface to utilize Refersh Button
 *   without coding an event handler in the View logic
 *   
 * *************************/

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Input;

namespace WeatherApp.ViewModel.Commands
{
    public class RefreshCommand : ICommand
    {
        public WeatherVM VM { get; set; }
        public event System.EventHandler CanExecuteChanged;

        public RefreshCommand(WeatherVM vm)         // passing the ViewModel Object so that the system does not generate a new view madel 
                                                    // every time button is clicked
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)       /// Can be used to check if certain condition are met before Command can be executed
        {
            return true;
        }

        public void Execute(object parameter)           //  What is executed when Coomand is called
        {
            VM.GetWeather();
        }
    }
}
