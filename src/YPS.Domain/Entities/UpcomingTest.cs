using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YPS.Domain.Entities
{
    public class UpcomingTest 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string Topic { get; set; }
        public string TestType { get; set; }
        [ForeignKey("Class")]
        public long ClassId { get; set; }
        [ForeignKey("Discipline")]
        public long DisciplineId { get; set; }
        public Class Class { get; set; }
        public Discipline Discipline { get; set; }

    }
}
