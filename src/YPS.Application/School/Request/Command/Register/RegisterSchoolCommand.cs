using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace YPS.Application.SchoolRequest.Command.Register
{
    public sealed class RegisterSchoolCommand : IRequest<long>
    {
        
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Locality { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumb { get; set; }
        
        public bool Confirmation { get; set; }
    }
}
