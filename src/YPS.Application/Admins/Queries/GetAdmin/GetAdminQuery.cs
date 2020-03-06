using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using YPS.Application.Interfaces;

namespace YPS.Application.Admins.Queries.GetAdmin
{
    public class GetAdminQuery : IRequest<AdminVm>
    {
        public long Id;
        public class GetAdminQueryHandler : IRequestHandler<GetAdminQuery, AdminVm>
        {
            private readonly IYPSDbContext _dbContext;
            private readonly IMapper _mapper;

            public GetAdminQueryHandler(IYPSDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<AdminVm> Handle(GetAdminQuery request, CancellationToken cancellationToken)
            {
                AdminVm admin = await _dbContext.Users
                       .ProjectTo<AdminVm>(_mapper.ConfigurationProvider)
                       .FirstOrDefaultAsync(x => x.Id == request.Id);

                return admin;
            }
        }
    }
}
