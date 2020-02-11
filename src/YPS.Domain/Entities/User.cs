using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using YPS.Domain.Entities.Base;

namespace YPS.Domain.Entities
{
    public class User : EntityBase
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DateOfBirth { get; set; }
        public long RoleId { get; set; }
        public long? SchoolId { get; set; }
        public School School { get; set; }
        public Role RoleOf { get; set; }
        public Pupil Pupil { get; set; }
        public Teacher Teacher { get; set; }
        public Parent Parent { get; set; }
    }
}
