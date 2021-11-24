using EventSchedules.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSchedules.Model
{
    public class Event
    {
        internal Event()
        { }

        public Event(string eventName, int eventUserId,  string description, DateTime holdingDate)
        {
            if (string.IsNullOrEmpty(eventName) || string.IsNullOrEmpty(eventUserId.ToString()) )
                throw new ArgumentNullException("Fill all required fields");

            Name = eventName;
            CreateDate = DateTime.UtcNow.Date;
            HoldingDate = holdingDate;
            UserId = eventUserId;                        
            Status = (int)EventStatus.Active;
            Description = description;           
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime CreateDate { get; set; }

        [Required]
        public DateTime HoldingDate { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        public int Status { get; set; } = (int)EventStatus.Active;

        [Required]
        public string Description { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
