using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YPS.Application.Interfaces;
using YPS.Domain.Entities;

namespace YPS.Application.Lessons.Commands.CreateJournalColumn
{
    public sealed class CreateJournalColumnCommand : IRequest<long>
    {
        public string Topic { get; set; }
        public long LessonId { get; set; }
        public long ClassId { get; set; }
        public List<List<MarkDto>> LessonMarks { get; set; }

        public sealed class CreateJournalColumnCommandHandler : IRequestHandler<CreateJournalColumnCommand, long>
        {
            private readonly IYPSDbContext _context;

            public CreateJournalColumnCommandHandler(IYPSDbContext context)
            {
                _context = context;
            }
            public async Task<long> Handle(CreateJournalColumnCommand request, CancellationToken cancellationToken)
            {
                Journal journal = await _context.Journals.SingleOrDefaultAsync(j => j.ClassId == request.ClassId);

                JournalColumn journalColumn = new JournalColumn
                {
                    Topic = request.Topic,
                    LessonId = request.LessonId,
                    JournalId = journal.Id,
                };

                _context.JournalColumns.Attach(journalColumn);
                await _context.SaveChangesAsync(cancellationToken);
                JournalColumn createdJC = await _context.JournalColumns.FindAsync(journalColumn.Id);

                foreach (List<MarkDto> subList in request.LessonMarks)
                {
                    foreach (MarkDto mark in subList)
                    {
                        if (mark.Value != null && mark.Type != 0 && mark.PupilId != 0 )
                        {
                            Mark newMark = new Mark
                            {
                                JournalColumnId = createdJC.Id,
                                MarkTypeId = mark.Type,
                                PupilId = mark.PupilId,
                                Value = mark.Value
                            };
                            await _context.Marks.AddAsync(newMark);
                        }
                    }
                }
                await _context.SaveChangesAsync(cancellationToken);

                return createdJC.Id;
            }
        }
    }
}
