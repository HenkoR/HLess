// ==========================================================================
//  HLess CMS
// ==========================================================================
//  Copyright (c) HLess (Henko Rabie)
//  All rights reserved. Licensed under the MIT license.
// ==========================================================================

using System;
using System.Collections.Generic;
using System.Text;

using HLess.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HLess.Data.EntityConfigurations
{
    class AppEntityTypeConfiguration : IEntityTypeConfiguration<App>
    {
        public void Configure(EntityTypeBuilder<App> builder)
        {
            builder.ToTable("Apps", ApplicationDbContext.DEFAULT_SCHEMA);

            builder.HasKey(o => o.Id);
            builder.Property(et => et.Id).ValueGeneratedNever();
        }
    }
}
