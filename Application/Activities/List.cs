using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<List<Activity>> { }

        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _content;
            private readonly ILogger<List> _logger;
            public Handler(DataContext content, ILogger<List> logger)
            {
                _logger = logger;
                _content = content;
            }

            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
               /*  try
                {
                    for (int i = 0; i < 10; i++)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        await Task.Delay(2000, cancellationToken);
                        _logger.LogInformation($"Task {i} has Completed");
                    }
                }
                catch (System.Exception)
                {

                    _logger.LogInformation("Task was cancelled");
                }
 */
                return await _content.Activities.ToListAsync();
            }
        }
    }
}