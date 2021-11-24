using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfSchedules.Models
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
