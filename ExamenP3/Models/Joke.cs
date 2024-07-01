using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SQLite;

namespace ExamenP3.Models
{
    public class Joke
    {
        [SQLite.PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string JokeText { get; set; }
        public string Code { get; set; }
    }
}
