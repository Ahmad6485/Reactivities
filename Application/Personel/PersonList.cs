using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Domain;

namespace Application.Personel
{
    public class PersonList
    {
        public class Query : IRequest<List<Domain.Personel>> { }
        public class Handler : IRequestHandler<Query, List<Domain.Personel>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Domain.Personel>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Personels.ToListAsync();
            }

        }
    }
}