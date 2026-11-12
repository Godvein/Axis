using System;
using System.Collections.Generic;
using System.Text;
using Axis.Api.Core.Interfaces;
using Axis.Api.Core.DTOs;
using Axis.Api.Events;
using Axis.Api.Core.Entities;
namespace Axis.Api.Application.Services
{
    public class GenericService<T> : IGenericService<T> where T : BaseEntity
    {
        public event EventHandler<UserCreatedEventArgs>? ObjectCreated;
        private readonly IGenericRepository<T> _repository;

        public GenericService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }
        
        protected virtual void OnObjectCreated(T entity)
        {
            if (ObjectCreated != null)
            ObjectCreated?.Invoke(this, new UserCreatedEventArgs(entity.Id, entity.type));
        }
        public async Task<List<T>> GetAllObjects()
        {
            return await _repository.GetAllObjects();
        }

        public async Task SaveObject(T entity)
        {
            await _repository.SaveObject(entity);
            OnObjectCreated(entity);
       }
        
    }
}
