using Microsoft.AspNetCore.Mvc;

namespace Looh.Api.Controllers.Schedule
{
    [Route("schedule")]
    public class ScheduleController  : ApiController
    {
        public IActionResult GetSchedule()
        {

            var isso = this;


            return Ok(Array.Empty<string>());
        }

    }
}
