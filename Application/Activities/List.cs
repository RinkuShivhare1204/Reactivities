using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<List<Activity>> {} //This is our mediator query

        public class Handler : IRequestHandler<Query, List<Activity>>
        {
        private readonly DataContext _context;
            public Handler(DataContext context)
            {
            _context = context;
            }
            //we passed our query which forms a request that we pass to our handler and then it returns data
            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Activities.ToListAsync(); //the data that we are looking for which is eventually the list of activities.
            }
        }
    }
}