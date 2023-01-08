using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace truthordrink.Model
{
    public class Question
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int userId { get; set; }

        [MaxLength(200)]
        public string question{ get; set;}
    }
}