using System;
using System.Collections.Generic;
using System.Text;

namespace YPS.Application.Models
{
    public class CreateUserResponse
    {
        public long CreatedId { get; set; }
        public IDictionary<string, string> Failures { get; set; }
    }
}
