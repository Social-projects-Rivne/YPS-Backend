using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YPS.Application.Interfaces;

namespace YPS.Application.JournalColumns.Queries.GetJournalColumnsByDisciplineQuery
{
    public class GetJournalColumnsByDisciplineQuery : IRequest<List<JournalColumnVm>>
    {
        public long ClassId { get; set; }
        public long DisciplineId { get; set; }

        public class GetJournalColumnsByDisciplineQueryHandler : IRequestHandler<GetJournalColumnsByDisciplineQuery, List<JournalColumnVm>>
        {
            private readonly IYPSDbContext _context;
            private readonly IMapper _mapper;

            public GetJournalColumnsByDisciplineQueryHandler(IYPSDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<JournalColumnVm>> Handle(GetJournalColumnsByDisciplineQuery request, CancellationToken cancellationToken)
            {
                List<JournalColumnVm> journalColumns = await _context.JournalColumns
                    .Where(x => x.Lesson.LessonDate.Year == DateTime.Now.Year && x.Lesson.DisciplineId == request.DisciplineId && x.Lesson.ClassId == request.ClassId)
                    .ProjectTo<JournalColumnVm>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                return journalColumns;
            }
        }
    }
}
