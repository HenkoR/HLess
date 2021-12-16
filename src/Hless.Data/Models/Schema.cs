using System;
using System.Collections.Generic;

namespace Hless.Data.Models
{
    public record Schema 
    {
        public long SchemaId { get; init; }
        public string Name { get; set; }
        public Dictionary<string, string> Definition { get; set; }
        public Dictionary<string, string> DraftDefinition { get; set; }
        public string CreatedBy { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime LastModified { get; set; }
        public DateTime? FirstPublished { get; set; }
        public DateTime? LastPublished { get; set; }
        public long ApplicationId { get; set; }

    }
    
}