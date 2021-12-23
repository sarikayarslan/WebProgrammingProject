using System;
using System.ComponentModel.DataAnnotations;

namespace WebProgrammingProject.Models
{
    public class Club
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime FoundationDate{ get; set; }
        public int PresidentId { get; set; }
        public User President { get; set; }

    }
}
