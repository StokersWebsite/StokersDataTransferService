using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace WebsiteStokers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("Register")]
        public IActionResult Register(string Firstname, string Lastname, string PhoneNumber, DateOnly Birthdate, string Adress, string PostalCode)
        {

        }
    }
}
