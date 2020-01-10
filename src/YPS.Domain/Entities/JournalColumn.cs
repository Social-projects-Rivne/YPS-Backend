using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YPS.Domain.Entities
{
    public class JournalColumn 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [ForeignKey("Homework")]
        public long HomeworkId { get; set; }
        [ForeignKey("Lesson")]
        public  long LessonId { get; set; }
        public  DateTime LessonDate { get; set; }
        public string Theme { get; set; }
        [ForeignKey("Journal")]
        public long JournalId { get; set; }

        public Homework Homework { get; set; }
        public Lesson Lesson { get; set; }
        public Journal Journal { get; set; }

    }
}
