using AutoMapper;
using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                _context = context;
                _mapper = mapper;   
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var activitiy = await _context.Activities.FindAsync(request.Activity.Id);

                _mapper.Map(request.Activity, activitiy);
                await _context.SaveChangesAsync();


                //if (activitiy != null)
                //{
                //    _context.Activities.Update(activitiy);
                //    await _context.SaveChangesAsync();
                //}
            }
        }
    }
}
