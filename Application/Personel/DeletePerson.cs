using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Personel
{
    public class DeletePer
    {
        public class Command : IRequest
        {
            public int id { get; set; }
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
                var person = await _content.Personels.FindAsync(request.id);
                _content.Remove(person);
                await _content.SaveChangesAsync();
            }
        }
    }
}