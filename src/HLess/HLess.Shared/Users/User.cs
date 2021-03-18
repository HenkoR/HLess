// ==========================================================================
//  HLess CMS
// ==========================================================================
//  Copyright (c) HLess (Henko Rabie)
//  All rights reserved. Licensed under the MIT license.
// ==========================================================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using Microsoft.AspNetCore.Identity;

namespace HLess.Shared.Users
{
    public class User : IdentityUser
    {
        [PersonalData]
        [StringLength(100, ErrorMessage = "The {0} can not be more than {1} characters.")]
        public string Name { get; set; }
        [PersonalData]
        [StringLength(100, ErrorMessage = "The {0} can not be more than {1} characters.")]
        public string Lastname { get; set; }
    }
}
