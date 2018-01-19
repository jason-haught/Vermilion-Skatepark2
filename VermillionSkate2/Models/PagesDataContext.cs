using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VermillionSkate2.Models
{
    public class PagesDataContext : DbContext
    {
        public DbSet<PagesDataModel> PagesData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Pages.db");
        }
    }
}
