using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListApplication.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        public ShellViewModel()
        {
            ActivateItem(new AddTodoViewModel());
        }

        public void LoadAddTodoPage()
        {
            ActivateItem(new AddTodoViewModel());
        }

        public void LoadViewTodoPage()
        {
            ActivateItem(new ViewTodoViewModel());
        }

        private string _test;

        public string Test
        {
            get { return _test; }
            set 
            { 
                _test = value; 
                NotifyOfPropertyChange(() => Test); 
            }
        }

    }
}
