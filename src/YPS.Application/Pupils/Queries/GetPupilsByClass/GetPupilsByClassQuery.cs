using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using YPS.Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace YPS.Application.Pupils.Queries.GetPupilsByClass
{
    public class GetPupilsByClassQuery : IRequest<List<PupilByClassVm>>
    {
        public long ClassId { get; set; }

        public class GetPupilsByClassQueryHandler : IRequestHandler<GetPupilsByClassQuery, List<PupilByClassVm>>
        {
            private readonly IYPSDbContext _context;
            private readonly IMapper _mapper;

            public GetPupilsByClassQueryHandler(IYPSDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<List<PupilByClassVm>> Handle(GetPupilsByClassQuery request, CancellationToken cancellationToken)
            {
                List<PupilByClassVm> result = await _context.Pupils
                    .Where(p => p.ClassToPupils.First().ClassId == request.ClassId)
                    .ProjectTo<PupilByClassVm>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                return result;
            }
        }
    }
}
