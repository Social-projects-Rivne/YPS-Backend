using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YPS.Domain.Entities
{
    public class JournalColumn 
    {
        [Key]
        public long Id { get; set; }
        public  DateTime LessonDate { get; set; }
        public string Theme { get; set; }
        
        [ForeignKey("Homework")]
        public long HomeworkId { get; set; }
        
        [ForeignKey("Lesson")]
        public  long LessonId { get; set; }

        [ForeignKey("Journal")]
        public long JournalId { get; set; }

        public virtual Homework Homework { get; set; }
        public virtual Lesson Lesson { get; set; }
        public virtual Journal Journal { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
    }
}
