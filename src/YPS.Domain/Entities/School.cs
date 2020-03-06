﻿using System;
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
        }

        public string Name { get; set; }
        public string ShortName { get; set; }
        public string RegistrationLink { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<UpcomingEvent> UpcomingEvents { get; set; }
        public ICollection<Auditorium> Auditoriums { get; set; }
    }
}
