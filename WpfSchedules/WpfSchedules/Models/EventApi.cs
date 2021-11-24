using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfSchedules.Models
{
    public class EventApi
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime HoldingDate { get; set; }

        public int UserId { get; set; }

        public int Status { get; set; }

        public string Description { get; set; }
    }
}
