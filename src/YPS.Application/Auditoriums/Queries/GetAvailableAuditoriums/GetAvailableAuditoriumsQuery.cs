using AutoMapper;
using MediatR;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YPS.Application.Interfaces;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using YPS.Domain.Entities;

namespace YPS.Application.Auditoriums.Queries.GetAvailableAuditoriums
{
    public sealed class GetAvailableAuditoriumsQuery : IRequest<List<AvailableAuditoriumVm>>
    {
        public ushort LessonNumber { get; set; }
        public long SchoolId { get; set; }
        public DateTime LessonDate { get; set; }
        public class GetAvailableAuditoriumsQueryHandler : IRequestHandler<GetAvailableAuditoriumsQuery, List<AvailableAuditoriumVm>>
        {
            private readonly IYPSDbContext _context;
            private readonly IMapper _mapper;

            public GetAvailableAuditoriumsQueryHandler(IYPSDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<AvailableAuditoriumVm>> Handle(GetAvailableAuditoriumsQuery request, CancellationToken cancellationToken)
            {
                var auditoriums = _context.Lessons
                    .Where(l => l.Auditorium.SchoolId == request.SchoolId && l.LessonDate == request.LessonDate && l.LessonNumber == request.LessonNumber)
                    .Select(x => x.Auditorium);

                var result = await _context.Auditoriums
                    .Where(cl => cl.SchoolId == request.SchoolId)
                    .Except(auditoriums)
                    .ProjectTo<AvailableAuditoriumVm>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                return result;
            }
        }
    }
}
