using System;
using System.Collections.Generic;
using System.Text;

namespace YPS.Application.Journals.Queries
{
    public class JournalViewModel
    {
        public List<JournalColumnHeadViewModel> JournalColumnHeads { get; set; }
        public List<PupilWithMarksViewModel> Pupils { get; set; }
    }
}
