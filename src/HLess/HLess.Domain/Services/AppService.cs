// ==========================================================================
//  HLess CMS
// ==========================================================================
//  Copyright (c) HLess (Henko Rabie)
//  All rights reserved. Licensed under the MIT license.
// ==========================================================================

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using HLess.Domain.Entities;
using HLess.Domain.Interfaces.Repositories;
using HLess.Domain.Interfaces.Services;

namespace HLess.Domain.Services
{
    public class AppService : IAppService
    {
        private readonly IDataRepository<App> _repository;

        public AppService(IDataRepository<App> repository)
        {
            _repository = repository;
            _repository.GetClaimsContext();
        }

        public Task<bool?> AddNew(App entity) =>
            _repository.AddAsync(entity);

        public Task<bool?> DeleteExisting(App entity) => 
            _repository.DeleteAsync(entity);

#nullable enable
        public Task<IEnumerable<App>?> FetchAllAsync() =>
            _repository.FindAllAsync();

        public Task<App?> FetchByIdAsync(params object[] keyValues) =>
            _repository.FindAsync(keyValues);

        public Task<IEnumerable<App>?> Query(Expression<Func<App, bool>> expression) =>
            _repository.Queryable(expression);
#nullable disable

        public Task<bool?> UpdateExisting(App entity) =>
            _repository.UpdateAsync(entity);
    }
}
