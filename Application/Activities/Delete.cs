using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Delete
    {
        public class Command : IRequest
        {
            public Guid id { get; set; }

        }
        public class Handler : IRequestHandler<Command>
        {
            public readonly DataContext _content;
            public Handler(DataContext content)
            {
                _content = content;
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var activity=await _content.Activities.FindAsync(request.id);
                _content.Remove(activity);
                await _content.SaveChangesAsync();
            }
        }
    }
}