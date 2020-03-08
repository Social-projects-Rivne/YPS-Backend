using System;
using System.Collections.Generic;
using System.Text;

namespace YPS.Domain.Entities
{
   public class ClassToPupil
    {
        public long ClassId { get; set; }
        public Class Class { get; set; }

        public long PupilId { get; set; }
        public Pupil Pupil { get; set; }
    }
}
