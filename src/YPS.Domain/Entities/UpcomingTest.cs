﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using YPS.Domain.Entities.Base;

namespace YPS.Domain.Entities
{
    public class UpcomingTest:EntityBase

    {
   

    public DateTime Date { get; set; }
    public string Topic { get; set; }
    public string TestType { get; set; }

    public long ClassId { get; set; }

    public long DisciplineId { get; set; }

    public virtual Class Class { get; set; }
    public virtual Discipline Discipline { get; set; }

    }
}