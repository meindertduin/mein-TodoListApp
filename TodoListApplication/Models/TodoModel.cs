using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListApplication.Models
{
    public class TodoModel
    {
        public Guid Id { get; set; }
        public string TodoTitle { get; set; }
        public DateTime TodoDate { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public string TodoDescription { get; set; }
        public bool IsCompleted { get; set; }


    }
}
