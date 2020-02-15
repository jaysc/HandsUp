using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandsUp.Shared.Models
{
    public class HandsUpEvent
    {
        [Column("Id")]
        [Required]
        public int HandsUpEventId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        public string Description { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? FinishedDate { get; set; }

        public ICollection<Person> People { get; set; }
        public Person CreatedByPerson { get; set; }
    }
}
