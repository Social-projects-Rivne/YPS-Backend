using AutoMapper;
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
    public class GetAdminQuery: IRequest<AdminViewModel>
    {
        public long Id;
        public class GetAdminQueryHandler : IRequestHandler<GetAdminQuery, AdminViewModel>
        {
            private readonly IYPSDbContext _dbContext;
            private readonly IMapper _mapper;

            public GetAdminQueryHandler(IYPSDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<AdminViewModel> Handle(GetAdminQuery request, CancellationToken cancellationToken)
            {
                AdminViewModel admin = await _dbContext.Users
                    .ProjectTo<AdminViewModel>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                return admin;
            }
        }
    }
}
