using System;
using System.Collections.Generic;
using System.Text;

namespace YPS.Application.JournalColumns.Commands.CreateJournalColumn
{
    public class MarkDto
    {
        public long PupilId { get; set; }
        public string Value { get; set; }
        public long TypeId { get; set; }
    }
}
