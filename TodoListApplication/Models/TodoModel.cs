using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

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
        private string _fullTime;

        public Brush Color { get; set; }

        public string FullTime
        {
            get 
            { 
                if(Minute < 10 || Hour < 10)
                {
                    if(Minute < 10 && Hour < 10) { _fullTime = "0" + Hour + " : " + "0" + Minute; }
                    else if(Minute < 10) { _fullTime = Hour + " : " + "0" + Minute; }
                    else { _fullTime = "0" + Hour + " : " + Minute; }
                }
                else { _fullTime = Hour + " : " + Minute; }
                if (Minute == 0 && Hour == 0) { _fullTime = string.Empty; }
                return _fullTime;
            }
            set { _fullTime = value; }
        }


    }
}
