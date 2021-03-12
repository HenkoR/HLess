// ==========================================================================
//  HLess CMS
// ==========================================================================
//  Copyright (c) HLess (Henko Rabie)
//  All rights reserved. Licensed under the MIT license.
// ==========================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using HLess.Data;
using HLess.Shared;
using HLess.Shared.Users;

using IdentityModel;

using IdentityServer4.Models;
using IdentityServer4.Services;

using Microsoft.AspNetCore.Identity;

namespace HLess.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IUserClaimsPrincipalFactory<User> _claimsFactory;
        protected UserManager<User> _userManager;
        private readonly IdentityDbContext _DbContext;

        public ProfileService(UserManager<User> userManager, IUserClaimsPrincipalFactory<User> claimsFactory, IdentityDbContext DbContext)
        {
            _userManager = userManager;
            _claimsFactory = claimsFactory;
            _DbContext = DbContext;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            //>Processing
            //var sub = context.Subject.GetSubjectId();
            //var user = await _userManager.FindByIdAsync(sub);

            var user = await _userManager.GetUserAsync(context.Subject);
            var principal = await _claimsFactory.CreateAsync(user);

            var claims = principal.Claims.ToList();
            claims = claims.Where(claim => context.RequestedClaimTypes.Contains(claim.Type)).ToList();

            if (claims.Any(x => x.Type == JwtClaimTypes.Name)) claims.Remove(claims.FirstOrDefault(x => x.Type == JwtClaimTypes.Name));
            // Add custom claims in token here based on user properties or any other source
            claims.Add(new Claim(Constants.UserIdClaim, user.Id ?? string.Empty));
            claims.Add(new Claim(JwtClaimTypes.Email, user.Email ?? string.Empty));

            claims.Add(new Claim(JwtClaimTypes.Name, user.Name ?? string.Empty));
            claims.Add(new Claim(JwtClaimTypes.FamilyName, user.Lastname ?? string.Empty));

            var roleClaims = context.Subject.FindAll(JwtClaimTypes.Role);
            context.IssuedClaims.AddRange(roleClaims);
            context.IssuedClaims.AddRange(claims);
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            //>Processing
            var user = await _userManager.GetUserAsync(context.Subject);

            context.IsActive = (user != null);
        }

    }
}
