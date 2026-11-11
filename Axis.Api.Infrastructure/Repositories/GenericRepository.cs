using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Axis.Api.Infrastructure.Data;
using Axis.Api.Core.Interfaces;

namespace Axis.Api.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DatabaseContext _context;

        public GenericRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAllObjects()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}
