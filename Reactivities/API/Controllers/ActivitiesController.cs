﻿using Application.Activities;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class ActivitiesController : BaseApiController
    {
        //private readonly IMediator _mediator;

        //private readonly DataContext _context;

        //public ActivitiesController(DataContext context)
        //{
        //    _context = context;
        //}

        //public ActivitiesController(IMediator mediator) 
        //{
        //    _mediator = mediator;
        //}

        [HttpGet] //api/activities

        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            //return await _context.Activities.ToListAsync();
            // return await _mediator.Send(new List.Query());
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")] //api/activities/fdfkdff

        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            //return await _context.Activities.FindAsync(id);
            return await Mediator.Send(new Details.Query { Id = id });
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity) {

            await Mediator.Send(new Create.Command { Activity = activity });
            return Ok();

        }
        [HttpPut ("{id}")]
        
        public async Task<IActionResult> EditActivity(Guid id, Activity activity)
        {
                activity.Id = id;
                await Mediator.Send(new Edit.Command { Activity=activity}) ;

                return Ok();
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteActivity(Guid id) 
        {
            await Mediator.Send(new Delete.Command { Id = id });
            return Ok();
        }
    }
}
