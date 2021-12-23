using System;
using System.ComponentModel.DataAnnotations;

namespace WebProgrammingProject.Models
{
    public class Club
    {
        public int Id { get; set; }
        public string ClubName { get; set; }
        [DataType(DataType.Date)]
        public DateTime FoundationDate{ get; set; }
        public string PresidentEmail { get; set; }
        public User President { get; set; }

    }
}
