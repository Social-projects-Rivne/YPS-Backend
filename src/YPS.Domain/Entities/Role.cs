using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace YPS.Domain.Entities
{
    public class Role
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }
        public  string Description { get; set; }
        [ForeignKey("User")]
        public long UserId { get; set; }
        public User User { get; set; }
    }
}
