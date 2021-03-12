// ==========================================================================
//  HLess CMS
// ==========================================================================
//  Copyright (c) HLess (Henko Rabie)
//  All rights reserved. Licensed under the MIT license.
// ==========================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HLess.Domain.Entities;
using HLess.Domain.Interfaces.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HLess.Areas.Api.Controllers.Apps
{
    [ApiExplorerSettings(GroupName = nameof(Apps))]
    public class AppsController : ApiController
    {
        private readonly ILogger<AppsController> _logger;
        private readonly IAppService _appService;

        public AppsController(ILogger<AppsController> logger, IAppService appService)
        {
            _logger = logger;
            _appService = appService;
        }

        [HttpGet]
        [Route("apps/")]
        [ProducesResponseType(typeof(IEnumerable<App>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetApps()
        {
            var apps = await _appService.FetchAllAsync();
            return Ok(apps);
        }

    }
}
