using EventSchedules.Data.Configurations;
using EventSchedules.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSchedules.Data
{

    public class EventShedulesDbContext : DbContext
    {
        public EventShedulesDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EventConfiguration());


            modelBuilder.Entity<User>()
                .HasMany(c => c.Events)
                .WithMany(u => u.Users);
        }
    }
 }


