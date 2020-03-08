using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using YPS.Domain.Entities.Base;

namespace YPS.Domain.Entities
{
    public class Pupil{
        public Pupil()
        {
            ParentToPupils = new HashSet<ParentToPupil>();
            Marks = new HashSet<Mark>();
            ClassToPupils = new HashSet<ClassToPupil>();
        }

        public long Id { get; set; }
        public User User { get; set; }

        
        public ICollection<ParentToPupil> ParentToPupils { get; set; }
        public ICollection<Mark> Marks { get; set; }
        public ICollection<ClassToPupil> ClassToPupils { get; set; }
    }
}
