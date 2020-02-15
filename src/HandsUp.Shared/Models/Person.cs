using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandsUp.Shared.Models
{
    public class Person
    {
        [Column("Id")]
        public int PersonId { get; set; }

        public string Name { get; set; }
    }
}
