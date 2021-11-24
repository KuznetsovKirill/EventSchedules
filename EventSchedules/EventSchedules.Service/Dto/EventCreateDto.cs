using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSchedules.Service.Dto
{
    public class EventCreateDto
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime HoldingDate { get; set; }

        [Required]
        public int UserCreateId { get; set; }
    }
}
