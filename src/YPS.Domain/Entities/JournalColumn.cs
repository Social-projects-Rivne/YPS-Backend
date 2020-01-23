using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using YPS.Domain.Entities.Base;

namespace YPS.Domain.Entities
{
    public class JournalColumn : EntityBase
    {
        public JournalColumn()
        {
            Marks = new HashSet<Mark>();
        }

        public  DateTime LessonDate { get; set; }
        public string Theme { get; set; }

        public long HomeworkId { get; set; }
        public virtual Homework Homework { get; set; }

        public  long LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }

        public long JournalId { get; set; }
        public virtual Journal Journal { get; set; }

        public  ICollection<Mark> Marks { get; set; }
    }
}
