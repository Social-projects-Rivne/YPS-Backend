using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using YPS.Domain.Entities.Base;

namespace YPS.Domain.Entities
{
    public class Role : EntityBase
    {
        public Role()
        {
            Users = new HashSet<User>();
        }
        
        public string Name { get; set; }
        public string Description { get; set; }
        public  ICollection<User> Users { get; set; }
    }
}
