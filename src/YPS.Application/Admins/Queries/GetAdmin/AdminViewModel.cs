using System;
using System.Collections.Generic;
using System.Text;

namespace YPS.Application.Admins.Queries.GetAdmin
{
    public class AdminViewModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
