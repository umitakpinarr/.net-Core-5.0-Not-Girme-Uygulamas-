using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Not_Girme_Uygulaması.Models.Context
{
    public class DatabaseContext : DbContext
    {


        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<students> students { get; set; }
        public DbSet<notes> notes { get; set; }
        public DbSet<lessons> lessons { get; set; }
        public DbSet<classes> classes { get; set; }





        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Primary Key identity e Seed değeri atar.
            //base.Database.ExecuteSqlCommand("DBCC CHECKIDENT('MyTable', RESEED, 1000);");

            base.OnConfiguring(optionsBuilder);
        }

    }
}
