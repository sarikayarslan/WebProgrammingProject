using Microsoft.AspNetCore.Identity;
using System;

namespace WebProgrammingProject.Models
{
    public class User: IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public Department? Department { get; set; }

    }
}
