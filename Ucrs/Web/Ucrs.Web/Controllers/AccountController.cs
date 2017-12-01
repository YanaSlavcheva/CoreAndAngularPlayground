namespace Ucrs.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Ucrs.Data.Models;

    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;

        public AccountController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("[action]")]
        public async Task<IActionResult> Register([FromForm] string email, [FromForm] string password)
        {
            // TODO: add validation
            // Use ViewModel and AutoMapper
            var user = new User { UserName = email, Email = email };
            var result = await this.userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                return this.Ok();
            }

            return this.BadRequest();
        }
    }
}