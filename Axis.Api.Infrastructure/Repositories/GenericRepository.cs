using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Axis.Api.Infrastructure.Data;
using Axis.Api.Core.Interfaces;
using Axis.Api.Core.Entities;

namespace Axis.Api.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
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

        public async Task SaveObject(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}
