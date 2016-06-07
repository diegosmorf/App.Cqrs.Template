﻿using App.Cqrs.Template.Core.Domain;
using App.Cqrs.Template.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace App.Cqrs.Template.Test.Unit.Infrastructure
{
    public class QueryServiceInMemory<TEntity> : IRepositoryQueryService<TEntity> where TEntity : IEntityBase
    {
        private readonly List<TEntity> _repository = new List<TEntity>();
        
        public TEntity Find(Expression<Func<TEntity, bool>> expressao)
        {
            if (_repository.Any())
            {
                return _repository.AsQueryable().First(expressao);
            }
            else
            {
                return default(TEntity);
            }
        }

        public IEnumerable<TEntity> All()
        {
            return _repository;
        }

        public IEnumerable<TEntity> FindList(Expression<Func<TEntity, bool>> expressao)
        {
            return _repository.AsQueryable().Where(expressao);
        }        

        public void Dispose()
        {            
        }
    }
}