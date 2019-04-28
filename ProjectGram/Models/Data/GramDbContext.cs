using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGram.Models.Data
{
    public class GramDbContext : IdentityDbContext<ApplicationUser>
    {

        public GramDbContext(DbContextOptions<GramDbContext> options)
            :base(options)
        {

        }

        public GramDbContext()
        {

        }
        //public DbSet<User>  Usuario { get; set; }
        public DbSet<Foto> Foto { get; set; }
        public DbSet<Follows> Follows { get;set; }
        public DbSet<Followed> Followed { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Likes> Likes { get; set; }
        public DbSet<Archive> Archives { get; set; }
        public DbSet<CommentLikes> CommentLikes { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProjectGram;Integrated Security=True;");
            //optionsBuilder.UseSqlServer("Server=tcp:echony.database.windows.net,1433;Initial Catalog=MusicDEMO;Persist Security Info=False;User ID=jhonas724;Password=@Hola1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here
            //modelBuilder.Entity<Country>()
            //.HasOne(a => a.CapitalCity)
            //.WithOne(a => a.Country)
            //.HasForeignKey<CapitalCity>(c => c.CountryID);
            ////Property Configurations
            //modelBuilder.Entity<Follows>()
            //.HasOne(a => a.Followed)
            //.WithOne(a => a.Follows)
            //.HasForeignKey<Follows>(c => c.UserId)
            //        .IsRequired();

            //modelBuilder.Entity<User>()
            //    .HasMany(f => f.Follows)
            //    .WithOne(u => u.User)
            //    .HasForeignKey(f => f.UserId);

            //modelBuilder.Entity<User>()
            //    .HasMany(f => f.FollowedList)
            //    .WithOne(u => u.User)
            //    .HasForeignKey(f => f.UserId);

            //modelBuilder.Entity<Follows>()
            //    .HasOne(f => f.Followed)
            //    .WithOne(fl => fl.Follows);

            //modelBuilder.Entity<Followed>()
            //    .HasOne(f => f.Follows)
            //    .WithOne(fl => fl.Followed);

            //modelBuilder.Entity<Notification>()
            //    .HasOne(n => n.ApplicationUser)
            //    .WithMany(u => u.Notifications)
            //    .HasForeignKey(f => f.ApplicationUserIdSend);

            //modelBuilder.Entity<Notification>()
            //    .HasOne(n => n.ApplicationUserReceive)
            //    .WithMany(u => u.Notifications)
            //    .HasForeignKey(f => f.ApplicationUserIdReceive);


            base.OnModelCreating(modelBuilder);

        }

    }
}
