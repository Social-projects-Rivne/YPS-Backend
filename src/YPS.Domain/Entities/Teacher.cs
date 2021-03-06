﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using YPS.Domain.Entities.Base;

namespace YPS.Domain.Entities
{
    public class Teacher 
    {
        public Teacher()
        {
            Lessons = new HashSet<Lesson>();
            Materials = new HashSet<Material>();
            Classes = new HashSet<Class>();
            TeacherToDisciplines = new HashSet<TeacherToDiscipline>();
            UpcomingEvents = new HashSet<UpcomingEvent>();
            UpcomingTests = new HashSet<UpcomingTest>();
        }
        public long Id { get; set; }
        public string  Degree { get; set; }
        
        public User User { get; set; }

        public ICollection<Lesson> Lessons { get; set; }
        public ICollection<UpcomingEvent> UpcomingEvents { get; set; }
        public ICollection<Class> Classes { get; set; }
        public ICollection<Material> Materials { get; set; }
        public ICollection<TeacherToDiscipline> TeacherToDisciplines { get; set; }
        public ICollection<UpcomingTest> UpcomingTests { get; set; }
    }
}
