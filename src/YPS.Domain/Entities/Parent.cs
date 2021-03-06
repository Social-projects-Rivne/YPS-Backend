﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using YPS.Domain.Entities.Base;

namespace YPS.Domain.Entities
{
    public class Parent 
    {
        public Parent()
        {
            ParentToPupils = new HashSet<ParentToPupil>();
        }

        public long Id { get; set; }

        public string WorkInfo { get; set; }

        public User User { get; set; }

        public ICollection<ParentToPupil> ParentToPupils { get; set; }
    }
}
