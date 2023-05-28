using System;
using FirstProj.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstProj.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
    }
}
