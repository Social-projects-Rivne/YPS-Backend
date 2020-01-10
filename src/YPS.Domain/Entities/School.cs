using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Text;

namespace YPS.Domain.Entities
{
    public class School 
    {
        public School()
        {
            Teachers = new HashSet<Teacher>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }

        public string ShortName { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
    }
}
