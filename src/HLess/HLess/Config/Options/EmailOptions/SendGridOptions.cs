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

namespace HLess.Config.Options.EmailOptions
{
    public class SendGridOptions
    {
        public string User { get; set; }
        public string ApiKey { get; set; }
    }
}
