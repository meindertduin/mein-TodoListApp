using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListApplication.ViewModels
{
    public class ViewTodoViewModel : Conductor<object>
    {
        public ViewTodoViewModel()
        {
            ActivateItem(new WeeklyTodoViewerViewModel());
        }
    }
}
