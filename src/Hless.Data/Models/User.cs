using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hless.Data.Models
{
    public record User
    {
        public long id { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public bool admin { get; set; }
        public long CreatedById { get; set; }
        public long UpdatedById { get; set; }
    }
}
