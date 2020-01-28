using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YPS.Application.Interfaces;
using YPS.Application.SchoolRequests.ViewModel;
using YPS.Domain.Entities;

namespace YPS.Application.SchoolRequests.Command
{
    public class ApproveCommand : IRequest<SchoolViewModel>
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public class ApproveCommandHandler : IRequestHandler<ApproveCommand, SchoolViewModel>
        {
            private IYPSDbContext _dbContext;
            private IMapper _mapper;

            public ApproveCommandHandler(IYPSDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<SchoolViewModel> Handle(ApproveCommand request, CancellationToken cancellationToken)
            {
                var school = new School
                {
                    Name = request.Name,
                    ShortName = request.ShortName
                };
                _dbContext.Schools.Add(school);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return new SchoolViewModel
                {
                    Name = request.Name,
                    ShortName = request.ShortName
                };
            }
        }
    }
}
