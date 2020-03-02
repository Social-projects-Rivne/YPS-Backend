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
using YPS.Domain.Entities;

namespace YPS.Application.SchoolRequests.Commands.DisapproveSchoolRequest
{
    public class DisapproveSchoolRequestCommand : IRequest<RemoveRequestViewModel>
    {
        public int Id { get; set; }
        public class DisapproveSchoolRequestCommandHandler : IRequestHandler<DisapproveSchoolRequestCommand, RemoveRequestViewModel>
        {
            private IYPSDbContext _dbContext;
            public DisapproveSchoolRequestCommandHandler(IYPSDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<RemoveRequestViewModel> Handle(DisapproveSchoolRequestCommand request, CancellationToken cancellationToken)
            {

                var schoolsRequests = _dbContext.SchoolRequests;
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
