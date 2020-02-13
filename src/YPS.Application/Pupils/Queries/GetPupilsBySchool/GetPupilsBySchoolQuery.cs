using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using YPS.Application.Interfaces;

namespace YPS.Application.Pupils.Queries.GetPupilsBySchool
{
    public sealed class GetPupilsBySchoolQuery : IRequest<List<PupilBySchoolVm>>
    {
        public long SchoolId { get; set; }
        public class GetPupilsBySchoolHandler : IRequestHandler<GetPupilsBySchoolQuery, List<PupilBySchoolVm>>
        {
            private readonly IYPSDbContext _context;
            private readonly IMapper _mapper;

            public GetPupilsBySchoolHandler(IYPSDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<PupilBySchoolVm>> Handle(GetPupilsBySchoolQuery request, CancellationToken cancellationToken)
            {
                List<PupilBySchoolVm> result = await _context.Pupils
                    .Where(cl => cl.SchoolId == request.SchoolId)
                    .ProjectTo<PupilBySchoolVm>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return result;
            }
        }
    }
}
