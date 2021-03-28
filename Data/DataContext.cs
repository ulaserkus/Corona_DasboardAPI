using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldAPI.Models;

namespace WorldAPI.Data
{
    public class DataContext:DbContext
    {

        public DataContext(DbContextOptions Options):base(Options)
        {

        }
        public DataContext()
        {

        }
        
        public DbSet<Country> Countries { get; set; }
       
        public DbSet<City>  Cities { get; set; }
            
        public DbSet<User> Users { get; set; }

        public DbSet<CountryDetails> CountryDetails { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WorldDb;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasIndex(x => x.CountryName).IsUnique();

            modelBuilder.Entity<User>().HasIndex(x => x.UserName).IsUnique();

                              
        }

    }
}
