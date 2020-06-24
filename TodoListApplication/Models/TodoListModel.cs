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
        private string filePath = @"D:\Dev\Test";

        public void AddTodo(TodoModel todo)
        {
            DeserializeJsonFile();

            todo.Id = Guid.NewGuid();
            todoList.Add(todo);
            WriteToJsonFile();
        }

        public void ChangeCompleStatusOfTodo(Guid id)
        {
            DeserializeJsonFile();
            TodoModel foundTodo = null;
            foreach(var todo in todoList)
            {
                if(id == todo.Id)
                {
                    foundTodo = todo;
                    break;
                }
            }
            if(foundTodo != null)
            {
                foundTodo.IsCompleted = !foundTodo.IsCompleted;
                WriteToJsonFile();
            }
        }

        public List<TodoModel> GiveTodosOfWeek(DateTime date)
        {
            DeserializeJsonFile();
            List<TodoModel> result = new List<TodoModel>();
            var greg = new GregorianCalendar();

            foreach(var todo in todoList)
            {
                if(greg.GetWeekOfYear(todo.TodoDate, CalendarWeekRule.FirstDay, DayOfWeek.Sunday)
                         == greg.GetWeekOfYear(date, CalendarWeekRule.FirstDay, DayOfWeek.Sunday))
                {
                    result.Add(todo);
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

        private void WriteToJsonFile()
        {
            string jsonString = SerializeTodoList();
            WriteJsonToTextFile(jsonString);
        }

        private string SerializeTodoList()
        {
            string jsonString = String.Empty;
            if(todoList.Count > 0)
            {
                jsonString = JsonConvert.SerializeObject(todoList, Formatting.Indented);
            }
            return jsonString;
        }

        private void DeserializeJsonFile()
        {
            string fileStringValue = File.ReadAllText(filePath + "\\todos.txt");
            todoList = JsonConvert.DeserializeObject<List<TodoModel>>(fileStringValue);
        }

        private void WriteJsonToTextFile(string jsonString)
        {
            File.WriteAllText(filePath + "\\todos.txt", jsonString);   
        }

    }
}
