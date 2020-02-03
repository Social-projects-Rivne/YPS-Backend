using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
               var admin = await _dbContext.Users.FirstOrDefaultAsync(
                    x => x.Id == request.Id);
                return new AdminViewModel
                {
                    Id = admin.Id,
                    FirstName = admin.FirstName,
                    Surname = admin.Surname,
                    MiddleName = admin.MiddleName,
                    Email = admin.Email,
                    PhoneNumber = admin.PhoneNumber,
                    ImageUrl = admin.ImageUrl,
                    DateOfBirth = admin.DateOfBirth

                };
            }
        }
    }
}
