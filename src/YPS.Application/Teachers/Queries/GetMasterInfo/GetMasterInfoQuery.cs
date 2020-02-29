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

namespace YPS.Application.Teachers.Queries.GetMasterInfo
{
    public sealed class GetMasterInfoQuery : IRequest<MasterVm>
    {
        public long Id { get; set; }

        public sealed class GetMasterInfoQueryHandler : IRequestHandler<GetMasterInfoQuery, MasterVm>
        {
            private readonly IYPSDbContext _context;
            private readonly IMapper _mapper;


            public GetMasterInfoQueryHandler(IYPSDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<MasterVm> Handle(GetMasterInfoQuery request, CancellationToken cancellationToken) =>
                await _context.Users
                    .ProjectTo<MasterVm>(_mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync(x => x.Id == request.Id);
        }
    }
}
