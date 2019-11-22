using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;

namespace RomainJ.MinieBicks.Data
{
    public partial class MineBricksContext : DbContext
    {
        
        public DbSet<Personne> Personne { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Adresse> Adresses { get; set; }
        public DbSet<Conges> Conges { get; set; }
        public DbSet<TypeConges> TypeConges { get; set; }

        
       

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=C:\\Users\\romai\\Source\\repos\\CESIC#\\J2_MiniBicks\\RomainJ.MinieBicks\\RomainJ.MinieBicks.Data\\MinieBicks.db");
        //"Data Source=MinieBicks.db"

    }
}
