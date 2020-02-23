using System;
using System.Collections.Generic;
using System.Text;

namespace YPS.Application.SchoolRequests.Commands.GetMasterRegisterLink
{
    public class RegisterLinkViewModel
    {
        public bool IsValid { get; set; }
        public long SchoolId { get; set; }
    }
}
