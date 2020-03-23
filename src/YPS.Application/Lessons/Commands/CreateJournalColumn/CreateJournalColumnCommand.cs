using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YPS.Application.Interfaces;
using YPS.Domain.Entities;

namespace YPS.Application.Lessons.Commands.CreateJournalColumn
{
    public sealed class CreateJournalColumnCommand : IRequest<string>
    {
        public string topic { get; set; }
        public long lessonId { get; set; }
        public long classId { get; set; }

        public List<List<string>> lessonMarks { get; set; }
        public sealed class CreateJournalColumnCommandHandler : IRequestHandler<CreateJournalColumnCommand, string>
        {
            private readonly IYPSDbContext _context;

            public CreateJournalColumnCommandHandler(IYPSDbContext context)
            {
                _context = context;
            }

            public async Task<string> Handle(CreateJournalColumnCommand request, CancellationToken cancellationToken)
            {
                Class @class = await _context.Classes.FindAsync(request.classId);
                Journal journal = await _context.Journals.FindAsync(@class.Journal.ClassId);
                Console.WriteLine("--------------");

                //JournalColumn journalColumn = new JournalColumn
                //{
                //    Topic = request.topic,
                //    LessonId = request.lessonId,
                //    JournalId = journal.Id,
                //};

               // _context.JournalColumns.Add(journalColumn);
                await _context.SaveChangesAsync(cancellationToken);

                return "Ok";
            }
        }
    }
}
