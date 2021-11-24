using EventSchedules.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSchedules.Data.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("EventSchedules");
            builder.HasKey(o => o.Id);
            builder.Property(t => t.Name);           
            builder.Property(t => t.CreateDate);           
            builder.Property(t => t.HoldingDate);
            builder.Property(t => t.UserId);           
            builder.Property(t => t.Status);
            builder.Property(t => t.Description);
                      
            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
