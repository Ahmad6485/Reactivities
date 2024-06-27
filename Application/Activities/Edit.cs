using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;
using Persistence;

namespace Application.Activities
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly IMapper _mapper;
            private readonly DataContext _content;
            public Handler(DataContext content, IMapper mapper)
            {
                _mapper = mapper;
                _content = content;
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _content.Activities.FindAsync(request.Activity.Id);
                //activity.Title = request.Activity.Title ?? activity.Title;
                _mapper.Map(request.Activity, activity);
                await _content.SaveChangesAsync();
            }
        }
    }
}
