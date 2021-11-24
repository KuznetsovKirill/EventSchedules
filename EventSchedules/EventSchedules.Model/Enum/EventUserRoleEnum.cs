using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSchedules.Model.Enum
{
    public enum EventUserRoleEnum : int
    {
        [Description("user role at event")]
        User = 0,
        [Description("admin role at event")]
        Admin = 1,
    }
}
