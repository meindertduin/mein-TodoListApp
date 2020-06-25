using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using TodoListApplication.Models;

namespace TodoListApplication.ViewModels
{
    public class AddTodoViewModel : Screen
    {
        private string _todoTitle;
        private DateTime _todoDate;
        private string _minute;
        private string _hour;
        private string _todoDescription;
        private string _notification = string.Empty;

        public AddTodoViewModel()
        {
            TodoDate = DateTime.Now;
        }

        public string TodoTitle
        {
            get { return _todoTitle; }
            set 
            { 
                _todoTitle = value; 
                NotifyOfPropertyChange(() => TodoTitle);
                NotifyOfPropertyChange(() => CanSubmitTodo);
            }
        }
        public DateTime TodoDate
        {
            get { return _todoDate; }
            set 
            { 
                _todoDate = value;
                NotifyOfPropertyChange(() => TodoDate);
                NotifyOfPropertyChange(() => CanSubmitTodo);
            }
        }
        public string Minute
        {
            get { return _minute; }
            set{ _minute = value; }
        }
        public string Hour
        {
            get { return _hour; }
            set { _hour = value; }
        }
        public string TodoDescription
        {
            get { return _todoDescription; }
            set { _todoDescription = value; }
        }

        public string Notification
        {
            get { return _notification; }
            set 
            { 
                _notification = value;
                NotifyOfPropertyChange(() => Notification);
            }
        }

        public bool CanSubmitTodo
        {
            get
            {
                return !string.IsNullOrEmpty(TodoTitle);
            }
        }

        public void SubmitTodo()
        {
            FillInAndAddTodo();
            EmptyFormFields();
            GiveFillInNotification();
        }

        private void FillInAndAddTodo()
        {
            Random rand = new Random();
            TodoListModel todoList = new TodoListModel();

            var todo = new TodoModel();
            todo.TodoTitle = TodoTitle;
            todo.TodoDate = TodoDate;

            if (!string.IsNullOrEmpty(Hour) || !string.IsNullOrEmpty(Minute))
            {
                todo.Hour = Int32.Parse(Hour);
                todo.Minute = Int32.Parse(Minute);
            }
            else
            {
                todo.Hour = 0;
                todo.Minute = 0;
            }

            todo.TodoDescription = TodoDescription;
            todo.IsCompleted = false;
            todo.Color = new SolidColorBrush(Color.FromRgb((byte)rand.Next(1, 255), (byte)rand.Next(1, 255), (byte)rand.Next(1, 233)));

            todoList.AddTodo(todo);
        }

        private void EmptyFormFields()
        {
            TodoTitle = string.Empty;

            Hour = string.Empty;
            NotifyOfPropertyChange(() => Hour);

            Minute = string.Empty;
            NotifyOfPropertyChange(() => Minute);

            TodoDescription = string.Empty;
            NotifyOfPropertyChange(() => TodoDescription);

            TodoDate = DateTime.Now;
        }

        private async void GiveFillInNotification()
        {
            Notification = "Form succesfully sumbited";
            await Task.Delay(5000);
            Notification = string.Empty;
        }




















    }
}
