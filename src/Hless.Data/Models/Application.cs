using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hless.Data.Models
{
    public record Application
    {
        public long ApplicationId { get; init; }
        public string Name { get; init; }
        public string OwnerId { get; init; }
        public string CreatedBy { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime LastModified { get; init; }
    }
}
