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
    public class CheckMasterLinkCommand: IRequest<RegisterLinkViewModel>
    {
        public string Link { get; set; }
        public class GetMasterLinkCommandHandler : IRequestHandler<CheckMasterLinkCommand, RegisterLinkViewModel>
        {
            private readonly IYPSDbContext _dbContext;
            private readonly IMapper _mapper;

            public GetMasterLinkCommandHandler(IYPSDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<RegisterLinkViewModel> Handle(CheckMasterLinkCommand request, CancellationToken cancellationToken)
            {
                var schoolRequest = await _dbContext.SchoolRequests.FirstOrDefaultAsync(x => x.RegistrationLink == request.Link);
                if (schoolRequest != null) 
                {
                    return new RegisterLinkViewModel
                    {
                        IsValid = true,
                        SchoolId = _dbContext.Schools.FirstOrDefault(x => x.Name == schoolRequest.Name).Id
                    }; 
                }
                else
                {
                    return new RegisterLinkViewModel
                    {
                        IsValid = false,
                        SchoolId = 0
                    };
                }
                
            }
        }
    }
}
