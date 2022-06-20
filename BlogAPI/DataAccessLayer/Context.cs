using BlogAPI.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.DataAccessLayer
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options)  : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)//bağlantı stringi
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-OE95DLD\\MSSQLSERVER01;database=CoreBlogAPIDbs; integrated security=true;");
        }

        public DbSet<Employee> Employees { get; set; }


    }
}
