﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using YPS.Domain.Entities.Base;

namespace YPS.Domain.Entities
{
    public class Homework : EntityBase
    {
        public Homework()
        {
            Marks = new HashSet<Mark>();
        }
        public string Title { get; set; }
        public JournalColumn JournalColumn { get; set; }

        public ICollection<Mark> Marks { get; set; }
    }
}
    