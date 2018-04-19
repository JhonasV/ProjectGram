using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGram.Models.Data
{
    public class GramDbContext : DbContext
    {


        public DbSet<User>  Usuario { get; set; }
        public DbSet<Foto> Foto { get; set; }
        public DbSet<Album> Album { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {

                optionsBuilder.UseSqlServer("Data Source=JHONAS\\SQLEXPRESS01;Initial Catalog=ProjectGram;Integrated Security=True;");
            }
    }
}
