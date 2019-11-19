using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System;


namespace RomainJ.MinieBicks.Data
{
    class MineBricksContext : DbContext
    {
        public DbSet<Personne> Personne { get; set; }
        public DbSet<Role> Role { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite(@"Data Source=C:\Users\alexi\OneDrive\Bureau\MinieZoneSolution-master\J2_MiniBicks\RomainJ.MinieBicks\RomainJ.MinieBicks.Data\MinieBicks.db");  
    }
}
