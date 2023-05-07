using LoginAPI.Project.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LoginAPI.Project
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<RegisterData> RegisterData { get; set; }

    }
}
