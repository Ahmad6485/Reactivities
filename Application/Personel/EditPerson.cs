using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Personel
{
    public class EditPerson
    {
        public class Command : IRequest
        {
            public Domain.Personel personel { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _content;
           // private readonly Mapper _mapper;

            public Handler(DataContext content)
            {
                //_mapper = mapper;
                _content = content;
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var person = await _content.Personels.FindAsync(request.personel.Id_Person);
                person.Name=request.personel.Name;
                //_mapper.Map(request.personel, person);
                await _content.SaveChangesAsync();
            }
        }
    }
}