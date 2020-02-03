using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using YPS.Domain.Entities.Base;

namespace YPS.Domain.Entities
{
    public class Material : EntityBase
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string FileUrl { get; set; }

        public long TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
