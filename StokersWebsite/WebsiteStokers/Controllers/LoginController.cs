using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using AbstractionLayer;
using FactoryLayer;

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
            IMembersData members = IMemberDataFactory.Get();
            members.RegisterMember(new DTOLayer.MemberDTO { Firstname = Firstname, Adress = Adress, Birthdate = Birthdate, Lastname = Lastname, PhoneNumber = PhoneNumber, PostalCode = PostalCode });
            return Ok();
            //fiets
        }
    }
}
