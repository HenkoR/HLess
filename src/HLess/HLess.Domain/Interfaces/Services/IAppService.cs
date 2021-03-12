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

namespace HLess.Domain.Interfaces.Services
{
    public interface IAppService
    {
#nullable enable
        Task<App?> FetchByIdAsync(params object[] keyValues);
        Task<IEnumerable<App>?> Query(Expression<Func<App, bool>> expression);
        Task<IEnumerable<App>?> FetchAllAsync();
#nullable disable
        Task<bool?> AddNew(App entity);
        Task<bool?> UpdateExisting(App entity);
        Task<bool?> DeleteExisting(App entity);
    }
}
