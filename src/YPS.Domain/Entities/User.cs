using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YPS.Domain.Entities
{
    public class User 
    {
        public User()
        {
            Roles = new HashSet<Role>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string FirstName { get; set; }
        
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string ImageUrl { get; set; }
       
        public Role Role { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Pupil Pupil { get; set; }
        public Teacher Teacher { get; set; }
        public Parent Parent { get; set; }
        public  ICollection<Role> Roles { get; set; }

    }
}
