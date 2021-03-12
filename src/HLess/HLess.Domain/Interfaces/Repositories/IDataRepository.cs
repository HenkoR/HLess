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

namespace HLess.Domain.Interfaces.Repositories
{
    public interface IDataRepository<TEntity>
    {
        IUnitOfWork UnitOfWork { get; }

        void GetClaimsContext();
        Task<TEntity> FindAsync(params object[] keyValues);
        Task<IEnumerable<TEntity>> FindAllAsync();
        Task<bool?> AddAsync(TEntity entity);
        Task<bool?> UpdateAsync(TEntity entity);
        Task<bool?> DeleteAsync(TEntity entity);

        Task<IEnumerable<TEntity>> Queryable(Expression<Func<TEntity, bool>> expression);
    }
}
