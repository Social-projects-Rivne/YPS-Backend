using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace YPS.Application.Journals.Queries
{
    public class GetJournalByDisciplineQuery : IRequest<JournalViewModel>
    {
        public long TeacherId { get; set; }
        public long DisciplineId { get; set; }

        public class GetJournalByDisciplineQueryHandler : IRequestHandler<GetJournalByDisciplineQuery, JournalViewModel>
        {
            public Task<JournalViewModel> Handle(GetJournalByDisciplineQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
