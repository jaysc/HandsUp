using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HandsUp.Shared.Models
{
    public class Event
    {
        public int ID { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        public string Description { get; set; }

        public DateTime? Date { get; set; }
        public bool Finished { get; set; }

        public ICollection<Person> People { get; set; }
    }
}
