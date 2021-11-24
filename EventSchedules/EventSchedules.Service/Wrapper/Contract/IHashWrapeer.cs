using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSchedules.Service.Wrapper.Contract
{   
    internal interface IHashWrapeer
    {
        string GetHashString(string s);
    }
}
