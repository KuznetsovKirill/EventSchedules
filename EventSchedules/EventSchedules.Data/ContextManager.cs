using EventSchedules.Data.Contract;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace EventSchedules.Data
{
    public class ContextManager : IContextManager
    {
        private static bool _isDbExists = false;
        private IServiceProvider _serviceProvide;
        private Dictionary<string, EventShedulesDbContext> _dbContextMap;

        public ContextManager(IServiceProvider serviceProvider)
        {
            _serviceProvide = serviceProvider;
            _dbContextMap = new Dictionary<string, EventShedulesDbContext>();
        }

        public T CreateRepositiry<T>(string id = "")
            where T : IRepository
        {
            var context = GetContext();

            if (!_isDbExists)
            {
                context.Database.EnsureCreated();
                _isDbExists = true;
            }
            var repo = _serviceProvide.GetService<T>();
            repo.SetContext(context);
            return repo;
        }

        private EventShedulesDbContext GetContext(string id = "")
        {
            if (!_dbContextMap.ContainsKey(id))
            {
                _dbContextMap[id] = _serviceProvide.GetService<EventShedulesDbContext>();
            }
            return _dbContextMap[id];
        }

        public void Save(string id = "")
        {
            GetContext(id).SaveChanges();
        }
    }
}
