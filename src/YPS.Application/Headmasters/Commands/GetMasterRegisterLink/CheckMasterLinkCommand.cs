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

namespace YPS.Application.SchoolRequests.Commands.GetMasterRegisterLink
{
    public class CheckMasterLinkCommand: IRequest<bool>
    {
        public string Link { get; set; }
        public class GetMasterLinkCommandHandler : IRequestHandler<CheckMasterLinkCommand, bool>
        {
            private readonly IYPSDbContext _dbContext;
            private readonly IMapper _mapper;

            public GetMasterLinkCommandHandler(IYPSDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<bool> Handle(CheckMasterLinkCommand request, CancellationToken cancellationToken)
            {
                var school = await _dbContext.Schools.FirstOrDefaultAsync(x => x.RegistrationLink == request.Link);
                if (school != null) 
                {
                    return true;
                    
                }
                else
                {
                    return false;
                }
                
            }
        }
    }
}
