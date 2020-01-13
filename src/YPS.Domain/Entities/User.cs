using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YPS.Domain.Entities
{
    public class User 
    {
        [Key]
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DateOfBirth { get; set; }

        [ForeignKey("RoleOf")]
        public long RoleId { get; set; }

        public virtual Role RoleOf { get; set; }
        public virtual ICollection<Pupil> Pupil { get; set; }
        public virtual ICollection<Teacher> Teacher { get; set; }
        public virtual ICollection<Parent> Parent { get; set; }
    }
}
