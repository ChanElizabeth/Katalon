using System;
using SmartCityFP.Models;

using Microsoft.EntityFrameworkCore;

namespace SmartCityFP.Data
{
    public class ApplicationDbContext: DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
    }
}

