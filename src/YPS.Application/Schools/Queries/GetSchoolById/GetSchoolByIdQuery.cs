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

namespace YPS.Application.Schools.Queries.GetSchoolById
{
    public sealed class GetSchoolByIdQuery : IRequest<SchoolVm>
    {
        public long SchoolId { get; set; }
        public sealed class GetSchoolByIdQueryHandler : IRequestHandler<GetSchoolByIdQuery, SchoolVm>
        {
            private readonly IYPSDbContext _context;
            private readonly IMapper _mapper;

            public GetSchoolByIdQueryHandler(IYPSDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<SchoolVm> Handle(GetSchoolByIdQuery request, CancellationToken cancellationToken)
            {
                SchoolVm vm = await _context.Schools
                    .ProjectTo<SchoolVm>(_mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync(x => x.Id == request.SchoolId);

                return vm;
            }
        }
    }
}
