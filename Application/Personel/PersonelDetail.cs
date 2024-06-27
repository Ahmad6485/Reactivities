using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.Personel
{
    public class PersonelDetail
    {
        public class Query : IRequest<Domain.Personel>
        {
            public int id_Person { get; set; }
        }

        public class Handler : IRequestHandler<Query, Domain.Personel>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Domain.Personel> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Personels.FindAsync(request.id_Person);
            }
        }
    }
}