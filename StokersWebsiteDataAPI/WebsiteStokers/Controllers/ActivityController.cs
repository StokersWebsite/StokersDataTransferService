using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using AbstractionLayer;
using FactoryLayer;
using Datalayer;

namespace WebsiteStokers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActivityController : ControllerBase
    {
        private readonly StokersContext _context;
        public ActivityController(StokersContext context)
        {
            _context = context;
        }
        [HttpPost]
        [Route("AddActivity")]
        public IActionResult AddActivity(string name, string description, DateTime date, string location, string MaxMembers)
        {
            IActivity activities = IActivityFactory.Get(_context);
            activities.AddActivity(new DTOLayer.ActivityDTO { name = name, description = description, date = new DateTime(date.Year, date.Month, date.Day), location = location, MaxMembers = MaxMembers });
            return Ok();
        }

        [HttpGet]
        [Route("GetActivities")]
        public JsonResult GetActivities()
        {
            return new JsonResult(_context.Activity.ToList());
        }
    }
}