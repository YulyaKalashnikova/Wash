using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wash
{
    public class WashContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<Drying> Dryings { get; set; }
        public DbSet<Machine> WashingMachines { get; set; }
        public DbSet<Powder> Powders { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        public WashContext()
        {
            //
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["WashDb"].ConnectionString);
        }
        
    }
}
