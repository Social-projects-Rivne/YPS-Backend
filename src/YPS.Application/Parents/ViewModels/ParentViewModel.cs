using System;
using System.Collections.Generic;
using System.Text;

namespace YPS.Application.Parents.ViewModels
{
    public class ParentViewModel
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public string WorkInfo { get; set; }
        public List<ChildInfoViewModel> Children { get; set; }
    }
}
