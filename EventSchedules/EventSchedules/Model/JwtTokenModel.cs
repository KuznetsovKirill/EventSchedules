using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEventSchedules.Model
{
    public class JwtTokenModel
    {
        public string access_token { get; set; }
        public int UserId { get; set; }
    }
}
