using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSchedules.Data.Contract
{
    public interface IContextManager
    {
        T CreateRepositiry<T>(string id = "")
            where T : IRepository;

        void Save(string id = "");
    }
}
