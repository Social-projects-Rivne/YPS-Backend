using System;
using System.Collections.Generic;
using System.Text;

namespace YPS.Application.Auth.Command.Event
{
    public  sealed class EventViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateOfCreating { get; set; }
        public string FullName { get; set; }
    }
}
