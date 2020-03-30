 using System;
using System.Collections.Generic;
using System.Text;

namespace YPS.Application.Journals.Queries
{
    public class PupilWithMarksViewModel
    {
        public string LastName { get; set; }
        public string Name { get; set; }
        public List<MarksForJournalViewModel> Marks { get; set; }
    }
}
