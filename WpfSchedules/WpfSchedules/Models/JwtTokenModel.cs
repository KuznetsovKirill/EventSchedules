using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfSchedules.Models
{
    public class JwtTokenModel
    {
        public string access_token { get; set; }
        public int UserId { get; set; }
        public string result { get; set; }
    }
}
