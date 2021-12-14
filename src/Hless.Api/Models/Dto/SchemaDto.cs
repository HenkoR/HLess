using Hless.Data.Models;
using System;
using System.Collections.Generic;

namespace Hless.Api.Models.Dto
{
    public record SchemaDto
    {
        public long SchemaId { get; init; }
        public string Name { get; init; }
        public Dictionary<string, string> Definition { get; init; }
        public Dictionary<string, string> DraftDefinition { get; init; }
        public string CreatedBy { get; init; }
        public long ApplicationId { get; init; }
    }

    public record SchemaCreateDto
    {
        public string Name { get; init; }
        public Dictionary<string, string> DraftDefinition { get; init; }
        public long ApplicationId { get; init; }
    }
}