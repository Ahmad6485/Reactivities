using Application.Activities;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities(CancellationToken ct)
        {
            return await Med.Send(new List.Query(),ct);
        }

        [HttpGet("{id}")] //api/activities/id
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await Med.Send(new Detail.Query { id = id });
        }
        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity)
        {
            await Med.Send(new Create.Command { Activity = activity });
            return Ok();
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> EditActivity(Guid id, Activity activity)
        {
            activity.Id = id;
            await Med.Send(new Edit.Command { Activity = activity });
            return Ok();
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteActivity(Guid Id)
        {
            await Med.Send(new Delete.Command { id = Id });
            return Ok();
        }
    }
}