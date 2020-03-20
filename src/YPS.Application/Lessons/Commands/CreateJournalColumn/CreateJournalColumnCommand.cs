using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace YPS.Application.Lessons.Commands.CreateJournalColumn
{
    public sealed class CreateJournalColumnCommand : IRequest<string>
    {
        public string Topic { get; set; }
        public long LessonId { get; set; }
        public long JournalId { get; set; }
    }
}
