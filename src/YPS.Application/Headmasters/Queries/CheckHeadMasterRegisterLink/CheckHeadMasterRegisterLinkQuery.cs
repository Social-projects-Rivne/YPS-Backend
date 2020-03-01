using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YPS.Application.Interfaces;

namespace YPS.Application.HeadMasters.Queries.CheckMasterRegisterLink
{
    public class CheckHeadMasterRegisterLinkQuery : IRequest<bool>
    {
        public string Link { get; set; }

        public class CheckHeadMasterRegisterLinkQueryHandler : IRequestHandler<CheckHeadMasterRegisterLinkQuery, bool>
        {
            private readonly IYPSDbContext _dbContext;

            public CheckHeadMasterRegisterLinkQueryHandler(IYPSDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<bool> Handle(CheckHeadMasterRegisterLinkQuery request, CancellationToken cancellationToken)
            {
                var school = await _dbContext.Schools.FirstOrDefaultAsync(x => x.RegistrationLink == request.Link);
                return school != null ? true : false;
            }
        }
    }
}
