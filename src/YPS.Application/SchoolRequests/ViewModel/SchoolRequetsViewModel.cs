using System;
using System.Collections.Generic;
using System.Text;

namespace YPS.Application.SchoolRequests.ViewModel
{
    public class SchoolRequestViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Locality { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumb { get; set; }
    }
}
