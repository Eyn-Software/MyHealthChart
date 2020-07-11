using MyHealthChart3.Models.ViewDataObjects;
using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ModelCounterparts;
using Syncfusion.SfCalendar.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyHealthChart3.ViewModels.ViewCounterparts
{
    public class CalendarViewModel : BaseViewModel
    {
        private IServerComms NetworkModule;
        private UserViewModel User;
        private CalendarEventCollection events;

        public CalendarEventCollection Events
        {
            get
            {
                return events;
            }
            set
            {
                SetValue(ref events, value);
            }
        }
        public ICommand SetCalendarCmd
        {
            get;
            private set;
        }
        public CalendarViewModel(UserViewModel Usr, IServerComms networkModule)
        {
            User = Usr;
            NetworkModule = networkModule;

            SetCalendarCmd = new Command(async () => await SetCalendar());
        }
        private async Task SetCalendar()
        {
            Events = await NetworkModule.GetAllAppointments(User);
        }
    }
}
