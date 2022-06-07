using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataContext : IdentityDbContext<Microsoft.AspNetCore.Identity.IdentityUser>
    {
        protected readonly IConfiguration Configuration;

        public DataContext()
        {
        }

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to mysql with connection string from app settings
            //var connectionString = Configuration.GetConnectionString("WebApiDatabase");
            //options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            //options.UseMySql("server=localhost; Port=1010; database=webapi; user=webapi; password=webapi", 
            //                 ServerVersion.AutoDetect("server=localhost; Port=1010; database=webapi; user=webapi; password=webapi"));
            options.UseMySql("server=db-ria2022; database=webapi; user=webapi; password=webapi",
                 ServerVersion.AutoDetect("server=db-ria2022; database=webapi; user=webapi; password=webapi"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Noticias> Noticias { get; set; }
        public DbSet<Documentos> Documentos { get; set; }
    }
}
