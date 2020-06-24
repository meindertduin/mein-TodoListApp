using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListApplication.ViewModels
{
    public class TimePickerViewModel : Screen
    {
        private readonly IEventAggregator _eventAggregator;
        private string _minute = "Hello";

        public TimePickerViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public string Minute
        {
            get { return _minute; }
            set 
            { 
                _minute = value;
                NotifyOfPropertyChange(() => Minute);
                
            }
        }

    }
}
