using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hless.Data.Models
{
    public record Content
    {
        public long ContentId { get; init; }
        public string ContentFinal { get; set; }
        public string DraftContent { get; set; }
        public string CreatedBy { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime LastModified { get; set; }
        public DateTime? FirstPublished { get; init; }
        public DateTime? LastPublished { get; init; }
        public long SchemaId { get; init; }
    }
}
