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

namespace YPS.Application.HeadMasters.Command.CheckMasterRegisterLink
{
    public class CheckMasterRegisterLinkCommand: IRequest<bool>
    {
        public string Link { get; set; }
        public class CheckMasterRegisterLinkCommandHandler : IRequestHandler<CheckMasterRegisterLinkCommand, bool>
        {
            private readonly IYPSDbContext _dbContext;
            private readonly IMapper _mapper;

            public CheckMasterRegisterLinkCommandHandler(IYPSDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<bool> Handle(CheckMasterRegisterLinkCommand request, CancellationToken cancellationToken)
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
