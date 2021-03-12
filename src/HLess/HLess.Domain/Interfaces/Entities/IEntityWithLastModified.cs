// ==========================================================================
//  HLess CMS
// ==========================================================================
//  Copyright (c) HLess (Henko Rabie)
//  All rights reserved. Licensed under the MIT license.
// ==========================================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace HLess.Domain.Interfaces.Entities
{
    public interface IEntityWithLastModified
    {
        public string LastModifiedBy { get; set; }
        public DateTimeOffset LastModified { get; set; }
    }
}
