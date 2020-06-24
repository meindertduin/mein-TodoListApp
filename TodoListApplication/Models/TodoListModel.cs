using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
