using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandsUp.Shared.Models
{
    public class Event
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool Finished { get; set; }
        public List<Person> People { get; set; }
    }
}
