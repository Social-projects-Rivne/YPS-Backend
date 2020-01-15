﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using YPS.Domain.Entities.Base;

namespace YPS.Domain.Entities
{    
    public class Parent  :EntityBase
    {
        public Parent()
        {
            ParentToPupils = new HashSet<ParentToPupil>();
        }
        
        public long UserId { get; set; }
        
        public string WorkInfo { get; set; }

        public virtual User User { get; set; }
        public  ICollection<ParentToPupil> ParentToPupils { get; set; }
    }
}
