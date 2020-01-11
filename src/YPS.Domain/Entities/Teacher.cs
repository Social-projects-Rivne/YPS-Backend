using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YPS.Domain.Entities
{
    public class Teacher 
    {
        public Teacher()
        {
            Materials = new HashSet<Material>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity) , ForeignKey("User")]
        public long Id { get; set; }
        [ForeignKey("School")]
        public long SchoolId { get; set; }
        public string  Degree { get; set; }
        public School School { get; set; }
        public  User User { get; set; }
        public ICollection<Material> Materials { get; set; }
    }
}
