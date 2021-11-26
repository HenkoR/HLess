using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hless.Api.Models.Dto
{
    public record ApplicationDto
    {
        public long ApplicationId { get; init; }
        public string Name { get; init; }
        public string OwnerId { get; init; }
    }

    public record ApplicationCreateDto
    {
        public string Name { get; init; }
        public string OwnerId { get; init; }
    }
}
