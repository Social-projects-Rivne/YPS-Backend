using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YPS.Application.Interfaces;
using YPS.Domain.Entities;

namespace YPS.Application.Marks.Queries.GetMarksByPupil
{
    public sealed class GetMarksByPupilQuery : IRequest<List<JournalColumnByPupilVm>>
    {
        public long DisciplineId { get; set; }
        public long PupilId { get; set; }

        public class GetMarksByPupilQueryHandler : IRequestHandler<GetMarksByPupilQuery, List<JournalColumnByPupilVm>>
        {
            private readonly IYPSDbContext _context;
            private readonly IMapper _mapper;

            public GetMarksByPupilQueryHandler(IYPSDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<JournalColumnByPupilVm>> Handle(GetMarksByPupilQuery request, CancellationToken cancellationToken)
            {

                List<JournalColumnByPupilVm> vm = new List<JournalColumnByPupilVm>();

                IQueryable<Mark> marks = _context.Marks
                   .Include(x => x.MarkType)
                   .Where(x => x.JournalColumnId == x.JournalColumnId && x.PupilId == request.PupilId);
                   
                var journalColumns = _context.JournalColumns
                    .Include(x => x.Marks)
                    .Include(x => x.Lesson.Discipline)
                    .Where(t => t.JournalId == t.JournalId && t.Lesson.DisciplineId == request.DisciplineId);

                foreach (var journalColumn in journalColumns)
                {
                    var marksOfPupil = journalColumn.Marks.Intersect(marks).AsQueryable();

                    vm.Add(new JournalColumnByPupilVm
                    {
                       Topic = journalColumn.Topic,
                       LessonDate = journalColumn.Lesson.LessonDate.ToString("MM.dd.yyyy"),
                       Discipline = journalColumn.Lesson.Discipline.Name,
                       Marks = marksOfPupil.ProjectTo<MarkByPupilDto>(_mapper.ConfigurationProvider).ToList()
                    });
                }

                return vm;
            }
        }
    }
}
