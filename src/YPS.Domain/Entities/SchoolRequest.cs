﻿using System;
using System.Collections.Generic;
using System.Text;
using YPS.Domain.Entities.Base;

namespace YPS.Domain.Entities
{
     public class SchoolRequest : EntityBase
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Locality { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}