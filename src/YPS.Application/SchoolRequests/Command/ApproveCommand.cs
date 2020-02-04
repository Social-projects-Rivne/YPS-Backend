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
using YPS.Application.SchoolRequests.ViewModel;
using YPS.Domain.Entities;

namespace YPS.Application.SchoolRequests.Command
{
    public class ApproveCommand : IRequest<SchoolViewModel>
    {
        public long Id { get; set; }
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
                var requests = _dbContext.SchoolRequests.AsNoTracking();                
                var school = new School
                {
                    Name = requests.FirstOrDefault(x => x.Id == request.Id).Name,
                    ShortName = requests.FirstOrDefault(x => x.Id == request.Id).ShortName
                };
                _dbContext.Schools.Add(school);
                await _dbContext.SaveChangesAsync(cancellationToken);

                _dbContext.SchoolRequests.FirstOrDefault(x => x.Id == request.Id).IsApproved = true;
                await _dbContext.SaveChangesAsync(cancellationToken);
                return new SchoolViewModel { Id = request.Id };   
            }
        }
    }
}
