using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebProgrammingProject.Models;

namespace WebProgrammingProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Club> Club { get; set; }
        public DbSet<ClubUser> ClubUser { get; set; }
        public DbSet<Advertisement> Advertisement { get; set; }
        public DbSet<JobsUser> JobsUser { get; set; }


    }
}
