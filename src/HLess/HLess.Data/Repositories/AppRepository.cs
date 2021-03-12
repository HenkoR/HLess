// ==========================================================================
//  HLess CMS
// ==========================================================================
//  Copyright (c) HLess (Henko Rabie)
//  All rights reserved. Licensed under the MIT license.
// ==========================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using HLess.Domain.Entities;
using HLess.Domain.Interfaces;
using HLess.Domain.Interfaces.Repositories;
using HLess.Shared;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HLess.Data.Repositories
{
    public class AppRepository : IDataRepository<App>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AppRepository> _logger;
        //private readonly HttpContext _httpContext;
        private string _userId;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public AppRepository(ApplicationDbContext context, ILogger<AppRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger;
            //_httpContext = contextAccessor.HttpContext;
        }

        public void GetClaimsContext()
        {
            //var claimsIdentity = _httpContext.User.Identity as ClaimsIdentity;

            //_userId = claimsIdentity.FindFirst(c => c.Type == Constants.UserIdClaim)?.Value;
        }

        public async Task<bool?> AddAsync(App entity)
        {
            try
            {
                entity.CreatedBy = _userId;
                await _context.Apps.AddAsync(entity);

                return await UnitOfWork.SaveEntitiesAsync(default);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to add App, reason: {ex.Message}");
            }

            return default;
        }

        public async Task<bool?> DeleteAsync(App entity)
        {
            try
            {
                _context.Apps.RemoveRange(entity);

                return await UnitOfWork.SaveEntitiesAsync(default);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to delete App, reason: {ex.Message}");
            }

            return default;
        }

        public async Task<IEnumerable<App>> FindAllAsync()
        {
            return (await _context.Apps.OrderBy(x => x.Name).ToListAsync()) ?? new List<App>();
        }

#nullable enable
        public async Task<App?> FindAsync(params object[] keyValues)
        {
            try
            {
                var result = await _context.Apps.FindAsync(keyValues);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to retrieve Apps, reasone: {ex.Message}");
            }
            return default;
        }

        public async Task<IEnumerable<App>?> Queryable(Expression<Func<App, bool>> expression)
        {
            try
            {
                var result = await _context.Apps.Where(expression).AsNoTracking().OrderBy(x => x.Name).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to query Apps, reason: {ex.Message}");
            }
            return default;
        }
#nullable disable

        public async Task<bool?> UpdateAsync(App entity)
        {
            try
            {
                _context.Apps.UpdateRange(entity);

                return await UnitOfWork.SaveEntitiesAsync(default);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to update App, reason: {ex.Message}");
            }

            return default;
        }
    }
}
