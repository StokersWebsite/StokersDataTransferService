using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using AbstractionLayer;
using FactoryLayer;

namespace WebsiteStokers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActivityController : ControllerBase
    {
        [HttpPost]
        [Route("AddActivity")]
        public IActionResult AddActivity(string name, string description, DateTime date, string location, string MaxMembers)
        {
            IActivityData activities = IActivityDataFactory.Get();
            activities.AddAcitivtyDAL(new DTOLayer.ActivityDTO { name = name, description = description, date = new DateOnly(date.Year, date.Month, date.Day), location = location, MaxMembers = MaxMembers });
            return Ok();
        }
    }
}