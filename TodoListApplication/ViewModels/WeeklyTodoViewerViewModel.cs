using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListApplication.Models;
using System.Globalization;

namespace TodoListApplication.ViewModels
{
    public class WeeklyTodoViewerViewModel : Screen
    {
        public BindableCollection<TodoModel> Sunday { get; set; }
        public BindableCollection<TodoModel> Monday { get; set; }
        public BindableCollection<TodoModel> Tuesday { get; set; }
        public BindableCollection<TodoModel> Whensday { get; set; }
        public BindableCollection<TodoModel> Thursday { get; set; }
        public BindableCollection<TodoModel> Friday { get; set; }
        public BindableCollection<TodoModel> Saturday { get; set; }


        public WeeklyTodoViewerViewModel()
        {
            Sunday = new BindableCollection<TodoModel>() { new TodoModel() { Id = Guid.NewGuid(), Hour = 12, Minute = 30, TodoDate = DateTime.Now, TodoTitle = "Clean up room", TodoDescription = "Do it now" } };
            SetUpDayCollections(DateTime.Now);

        }

        private void SetUpDayCollections(DateTime date)
        {
            var todoReader = new TodoListModel();
            var todosOfWeek = todoReader.GiveTodosOfWeek(date);

            foreach(var todo in todosOfWeek)
            {
                SortTodoToCollection(todo);
            }
        }

        private void SortTodoToCollection(TodoModel todo)
        {
            var greg = new GregorianCalendar();
            int dayOfWeek = (int)greg.GetDayOfWeek(todo.TodoDate);

            switch (dayOfWeek)
            {
                default:
                    break;
                case 7:
                    if (Sunday == null)
                    {
                        Sunday = new BindableCollection<TodoModel>();
                    }
                    Sunday.Add(todo);
                    break;
                case 1:
                    if (Monday == null)
                    {
                        Monday = new BindableCollection<TodoModel>();
                    }
                    Monday.Add(todo);
                    break;
                case 2:
                    if (Tuesday == null)
                    {
                        Tuesday = new BindableCollection<TodoModel>();
                    }
                    Tuesday.Add(todo);
                    break;
                case 3:
                    if(Whensday == null)
                    {
                        Whensday = new BindableCollection<TodoModel>();
                    }
                    Whensday.Add(todo);
                    break;
                case 4:
                    if (Thursday == null)
                    {
                        Thursday = new BindableCollection<TodoModel>();
                    }
                    Thursday.Add(todo);
                    
                    break;
                case 5:
                    if (Friday == null)
                    {
                        Friday = new BindableCollection<TodoModel>();
                    }
                    Friday.Add(todo);
                    break;
                case 6:
                    if (Saturday == null)
                    {
                        Saturday = new BindableCollection<TodoModel>();
                    }
                    Saturday.Add(todo);
                    break;
            }
        }
    }
}
