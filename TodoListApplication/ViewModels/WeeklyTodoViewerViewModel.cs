using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListApplication.Models;
using System.Globalization;
using Syncfusion.Windows.Shared;
using System.Windows;
using System.Windows.Media;

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

        private DateTime loadedDate;

        private string _loadedWeek;
        private string[] _loadedDates = new string[7];
        private Random rand = new Random();

        public string LoadedWeek
        {
            get 
            { 
                return _loadedWeek; 
            }
            set 
            { 
                _loadedWeek = value;
                NotifyOfPropertyChange(() => LoadedWeek);
            }
        }

        public string[] LoadedDates
        {
            get
            {
                return _loadedDates; 
            }
            set 
            {
                _loadedDates = value;
                NotifyOfPropertyChange(() => LoadedDates);
            }
        }

        public WeeklyTodoViewerViewModel()
        {
            loadedDate = DateTime.Now;
            SetUpDayCollections(loadedDate);
            LoadedWeek = loadedDate.Day.ToString();
            SetLoadedDatesAlligned();
        }

        public void LoadPreviousWeek()
        {
            loadedDate = loadedDate.AddDays(-(double)7.0);
            SetUpDayCollections(loadedDate);
            LoadedWeek = loadedDate.Day.ToString();
            SetLoadedDatesAlligned();
        }

        public void LoadNextWeek()
        {
            loadedDate = loadedDate.AddDays((double)7.0);
            SetUpDayCollections(loadedDate);
            LoadedWeek = loadedDate.Day.ToString();
            SetLoadedDatesAlligned();
        }

        public void ChangeCheckedValueOfTodo(Guid id)
        {
            var todoWriter = new TodoListModel();
            todoWriter.ChangeCompleStatusOfTodo(id);
        }
        private void SetUpDayCollections(DateTime date)
        {
            var todoReader = new TodoListModel();
            var todosOfWeek = todoReader.GiveTodosOfWeek(date);

            CreateCollections();

            foreach(var todo in todosOfWeek)
            {
                todo.Color = new SolidColorBrush(Color.FromRgb((byte)rand.Next(1, 255), (byte)rand.Next(1, 255), (byte)rand.Next(1, 233)));
                SortTodoToCollection(todo);
            }
        }

        private void SetLoadedDatesAlligned()
        {
            int dayOfWeekOfLoaded = GetDayOfWeek(loadedDate);
            DateTime firstDateOfWeek = loadedDate.AddDays((double)-dayOfWeekOfLoaded);
            for (int i = 0; i < _loadedDates.Length; i++)
            {
                _loadedDates[i] = firstDateOfWeek.Day.ToString() + " " + firstDateOfWeek.ToString("MMMM");
                firstDateOfWeek = firstDateOfWeek.AddDays((double)1.0);
            }
            NotifyOfPropertyChange(() => LoadedDates);
        }

        private void CreateCollections()
        {
            Sunday = new BindableCollection<TodoModel>();
            Monday = new BindableCollection<TodoModel>();
            Tuesday = new BindableCollection<TodoModel>();
            Whensday = new BindableCollection<TodoModel>();
            Thursday = new BindableCollection<TodoModel>();
            Friday = new BindableCollection<TodoModel>();
            Saturday = new BindableCollection<TodoModel>();

            NotifyOfPropertyChange(() => Sunday);
            NotifyOfPropertyChange(() => Monday);
            NotifyOfPropertyChange(() => Tuesday);
            NotifyOfPropertyChange(() => Whensday);
            NotifyOfPropertyChange(() => Thursday);
            NotifyOfPropertyChange(() => Friday);
            NotifyOfPropertyChange(() => Saturday);
        }

        //returns the day of week in integer with 1 being monday and 7 being sunday
        private int GetDayOfWeek(DateTime date)
        {
            var greg = new GregorianCalendar();
            return (int)greg.GetDayOfWeek(date);
        }

        private void SortTodoToCollection(TodoModel todo)
        {

            int dayOfWeek = GetDayOfWeek(todo.TodoDate);
            switch (dayOfWeek)
            {
                default:
                    break;
                case 1:
                    Monday.Add(todo);
                    break;
                case 2:
                    Tuesday.Add(todo);
                    break;
                case 3:
                    Whensday.Add(todo);
                    break;
                case 4:
                    Thursday.Add(todo);     
                    break;
                case 5:
                    Friday.Add(todo);
                    break;
                case 6:
                    Saturday.Add(todo);
                    break;
                case 0:
                    Sunday.Add(todo);
                    break;
            }
        }
    }
}
