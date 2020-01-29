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
    public class DisapproveCommand : IRequest<RemoveRequestViewModel>
    {
        public int Id { get; set; }
        public class DisapproveCommandHandler : IRequestHandler<DisapproveCommand, RemoveRequestViewModel>
        {
            private IYPSDbContext _dbContext;
            private IMapper _mapper;
            public DisapproveCommandHandler(IYPSDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<RemoveRequestViewModel> Handle(DisapproveCommand request, CancellationToken cancellationToken)
            {
               
                var schoolsRequests=_dbContext.SchoolRequests;
                schoolsRequests.FirstOrDefault(x => x.Id == request.Id).IsApproved = false;
                await _dbContext.SaveChangesAsync(cancellationToken);

                return new RemoveRequestViewModel
                {                   
                    Id = request.Id                    
                };
            }
        }
    }
}
