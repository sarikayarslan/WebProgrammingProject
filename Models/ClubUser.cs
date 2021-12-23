using System;
using System.ComponentModel.DataAnnotations;

namespace WebProgrammingProject.Models
{
    public class ClubUser
    {
        public int Id { get; set; }
        public string UserId{ get; set; }
        public User User { get; set; }
        public int ClubId { get; set; }
        public Club Club{ get; set; }
        public string UserMission { get; set; }

        [DataType(DataType.Date)]
        public DateTime JoinDate { get; set; }
    }
}
