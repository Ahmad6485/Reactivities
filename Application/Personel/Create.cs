using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Personel
{
    public class Create
    {
        public class Command : IRequest
        {
            public Domain.Personel person { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _content;
            public Handler(DataContext content)
            {
                _content = content;
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                _content.Personels.Add(request.person);
                await _content.SaveChangesAsync();
            }
        }
    }
}