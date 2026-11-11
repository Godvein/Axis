using System;
using System.Collections.Generic;
using System.Text;
using Axis.Api.Core.Interfaces;
using Axis.Api.Core.DTOs;
namespace Axis.Api.Application.Services
{
    public class GenericService<T> : IGenericService<T>
    {
        private readonly IGenericRepository<T> _repository;

        public GenericService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<List<T>> GetAllObjects()
        {
            return await _repository.GetAllObjects();
        }
        
    }
}
