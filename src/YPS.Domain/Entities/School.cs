using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Text;
using YPS.Domain.Entities.Base;

namespace YPS.Domain.Entities
{
    public class School : EntityBase
    {
        public School()
        {
            Users = new HashSet<User>();
            UpcomingEvents = new HashSet<UpcomingEvent>();
            Auditoriums = new HashSet<Auditorium>();
            Disciplines = new HashSet<Discipline>();
        }

        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Locality { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string RegistrationLink { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<UpcomingEvent> UpcomingEvents { get; set; }
        public ICollection<Auditorium> Auditoriums { get; set; }
        public ICollection<Discipline> Disciplines { get; set; }
    }
}
