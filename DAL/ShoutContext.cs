using Microsoft.EntityFrameworkCore;
using Shout.Models;
using System.Collections.Generic;

namespace Shout.DAL
{
    public class ShoutContext : DbContext
    {
        public DbSet<Users> Utilisateurs { get; set; }
        public DbSet<Shouts> Shouts { get; set; }
        public DbSet<Follow> Follower { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseMySQL("server=localhost;database=shoutDb;user=root;password=P@ssword");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Users>(Entity =>
            {
                Entity.HasKey(e => e.Id);
                Entity.Property(e => e.Pseudo).IsRequired();
                Entity.Property(e => e.Password).IsRequired();
                Entity.HasMany(e => e.Shoutlist).WithOne(e => e.Owner); // Liaison des tables users/shout
                Entity.HasMany(e => e.FollowingList).WithOne(e => e.Follower);// Liaison des tables users/follow
            });

            modelBuilder.Entity<Shouts>(Entity =>
            {
                Entity.HasKey(e => e.Id);
                Entity.Property(e => e.Publication).IsRequired();
                Entity.Property(e => e.DatePublication).IsRequired();
                Entity.HasOne(e => e.Owner).WithMany(e => e.Shoutlist);// Liaison des tables users/shout
            });

            modelBuilder.Entity<Follow>(Entity =>
            {
                Entity.HasKey(e => e.Id);
                Entity.HasOne(e => e.Follower).WithMany(e => e.FollowingList);// Liaison des tables users/follow
            });


        }        

        public DbSet<Shout.Models.UserAuth> UserAuth { get; set; }
        public IEnumerable<object> Users { get; internal set; }
    }
}
