using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace TodoListApplication.Models
{
    public class TodoListModel
    {
        private List<TodoModel> todoList = new List<TodoModel>();
        private string filePath = Directory.GetCurrentDirectory();
        public void AddTodo(TodoModel todo)
        {
            DeserializeJsonFile();
            todo.Id = Guid.NewGuid();

            if (todoList == null)
            {
                todoList = new List<TodoModel>();
                WriteToJsonFile();
            }

            todoList.Add(todo);
            WriteToJsonFile();
        }

        public void ChangeCompleStatusOfTodo(Guid id)
        {
            var todoToChange = FindTodoModel(id);
            if(todoToChange != null)
            {
                todoToChange.IsCompleted = !todoToChange.IsCompleted;
                WriteToJsonFile();
            }
        }

        public void DeleteTodo(Guid id)
        {
            DeserializeJsonFile();
            var todoToDelete = FindTodoModel(id);
            if (todoToDelete != null)
            {
                todoList.Remove(todoToDelete);
                WriteToJsonFile();
            }
        }

        public List<TodoModel> GiveTodosOfWeek(DateTime date)
        {
            DeserializeJsonFile();
            List<TodoModel> result = new List<TodoModel>();
            var greg = new GregorianCalendar();

            if(todoList == null)
            {
                todoList = new List<TodoModel>();
                WriteToJsonFile();
            }
            if(todoList.Count > 0)
            {
                foreach (var todo in todoList)
                {
                    if (greg.GetWeekOfYear(todo.TodoDate, CalendarWeekRule.FirstDay, DayOfWeek.Sunday)
                             == greg.GetWeekOfYear(date, CalendarWeekRule.FirstDay, DayOfWeek.Sunday))
                    {
                        result.Add(todo);
                    }
                }
            }
            
            result = result.OrderBy(o => (float)o.Hour + (o.Minute / 60.0)).ToList();
            return result;
        }   

        public List<TodoModel> GiveTodosOfDate(DateTime date)
        {
            DeserializeJsonFile();
            List<TodoModel> result = new List<TodoModel>();
            foreach(var todo in todoList)
            {
                if(todo.TodoDate.Date == date.Date)
                {
                    result.Add(todo);
                }
            }
            return result;
        }

        private TodoModel FindTodoModel(Guid id)
        {
            DeserializeJsonFile();
            TodoModel foundTodo = null;
            foreach (var todo in todoList)
            {
                if (id == todo.Id)
                {
                    foundTodo = todo;
                    break;
                }
            }
            return foundTodo;
        }

        private void WriteToJsonFile()
        {
            string jsonString = SerializeTodoList();
            WriteJsonToTextFile(jsonString);
        }

        private string SerializeTodoList()
        {
            string jsonString = string.Empty;
            if(todoList.Count > 0)
            {
                jsonString = JsonConvert.SerializeObject(todoList, Formatting.Indented);
            }
            return jsonString;
        }

        private void DeserializeJsonFile()
        {
            if (File.Exists(filePath + @"\todos.txt"))
            {
                string fileStringValue = File.ReadAllText(filePath + @"\todos.txt");
                todoList = JsonConvert.DeserializeObject<List<TodoModel>>(fileStringValue);
            }
            else
            {
                File.CreateText(filePath + @"\todos.txt");
                WriteJsonToTextFile("[]");
                string fileStringValue = File.ReadAllText(filePath + @"\todos.txt");
                todoList = JsonConvert.DeserializeObject<List<TodoModel>>(fileStringValue);
            }
            
        }

        private void WriteJsonToTextFile(string jsonString)
        {
            File.WriteAllText(filePath + "\\todos.txt", jsonString);   
        }

    }
}
