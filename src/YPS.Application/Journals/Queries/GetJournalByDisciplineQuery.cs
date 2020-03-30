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

namespace YPS.Application.Journals.Queries
{
    public class GetJournalByDisciplineQuery : IRequest<JournalViewModel>
    {
        public long ClassId { get; set; }
        public long DisciplineId { get; set; }

        public class GetJournalByDisciplineQueryHandler : IRequestHandler<GetJournalByDisciplineQuery, JournalViewModel>
        {
            private readonly IYPSDbContext _context;
            private readonly IMapper _mapper;

            public GetJournalByDisciplineQueryHandler(IYPSDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<JournalViewModel> Handle(GetJournalByDisciplineQuery request, CancellationToken cancellationToken)
            {
                List<JournalColumnHeadViewModel> headers = await _context.Lessons
                    .Where(x => x.LessonDate.Year == DateTime.Now.Year && x.DisciplineId == request.DisciplineId && x.ClassId == request.ClassId && x.JournalColumn != null)
                    .ProjectTo<JournalColumnHeadViewModel>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                List<PupilWithMarksViewModel> pupils = await _context.ClassesToPupils
                    .Where(p => p.ClassId == request.ClassId)
                    .Select(p => p.Pupil)
                    .ProjectTo<PupilWithMarksViewModel>(_mapper.ConfigurationProvider)
                    .OrderBy(e => e.FullName)
                    .ToListAsync();

                return new JournalViewModel
                {
                    JournalColumnHeads = headers,
                    Pupils = pupils
                };
            }
        }
    }
}
