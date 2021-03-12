// ==========================================================================
//  HLess CMS
// ==========================================================================
//  Copyright (c) HLess (Henko Rabie)
//  All rights reserved. Licensed under the MIT license.
// ==========================================================================

using System;
using System.Collections.Generic;
using System.Text;

using HLess.Domain.Interfaces.Entities;

namespace HLess.Domain.Entities
{
    public class App : Entity, IEntityWithLastModified, IEntityWithVersion
    {
        protected override string IdType => "app";
        public string Name { get; set; }
        public string Description { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTimeOffset LastModified { get; set; }

        public long Version { get; set; }
    }
}
