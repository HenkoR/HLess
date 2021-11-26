using System;

namespace Hless.Data.Models
{
    public record Schema 
    {
        public long SchemaId { get; init; }
        public string Name { get; init; }
        public string Definition { get; init; }
        public string DraftDefinition { get; init; }
        public string CreatedBy { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime LastModified { get; init; }
        public DateTime? FirstPublished { get; init; }
        public DateTime? LastPublished { get; init; }
        public long ApplicationId { get; init; }

    }
    
}