using System;
using System.Collections.Generic;
using System.Text;

namespace Axis.Api.Core.Interfaces
{
    public interface IGenericRepository<T>
    {
        public Task<List<T>> GetAllObjects();
        public Task SaveObject(T entity);
    }
}
