using AutoMapper;
using Domain;
using MediatR;
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
        private readonly DataContext _context;
        private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
            _mapper = mapper;
            _context = context;
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                //This is the activity that we are tracking when we get this from Entity framework
                var activity = await _context.Activities.FindAsync(request.Activity.Id); //To go and get the activity from our database

                //we are tracking this activity in memory
                 
                //This is what we are goint to save in our database 
                _mapper.Map(request.Activity, activity);
                //when we update this property as we're doing with this statement, then Entity Framework is then tracking that 
                //particular entity

                await _context.SaveChangesAsync(); //we call this method to save the changes that's when our database is getting updated
            }
        }
    }
}