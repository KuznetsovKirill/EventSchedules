using EventSchedules.Model;
using EventSchedules.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSchedules.Service.Dto
{
    public class EventDto
    {
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
    }
}
