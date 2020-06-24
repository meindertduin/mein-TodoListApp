using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
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

        private TodoListModel todoList = new TodoListModel();

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

        public bool CanSubmitTodo
        {
            get
            {
                return !String.IsNullOrEmpty(TodoTitle);
            }
        }

        public void SubmitTodo()
        {
            var todo = new TodoModel();
            todo.TodoTitle = TodoTitle;
            todo.TodoDate = TodoDate;
            todo.Hour = Int32.Parse(Hour);
            todo.Minute = Int32.Parse(Minute);
            todo.TodoDescription = TodoDescription;
            todo.IsCompleted = false;

            todoList.AddTodo(todo);

        }




















    }
}
