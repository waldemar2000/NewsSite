using NewsSite.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace NewsSite.Controllers
{

    [Route("check")]
    public class CheckController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public CheckController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet, Route("login")]
        async public Task<IActionResult> Login(string EmailForm)
        {
            var user = await userManager.FindByEmailAsync(EmailForm);
            await signInManager.SignInAsync(user, true);
            return Ok(user);
        }


        [HttpGet, Route("view/OpenNews")]
        public IActionResult ViewOpenNews()
        {

            return Ok();
        }

     
       [Authorize(Policy = "HiddenNews")]
        [HttpGet, Route("view/HiddenNews")]
        public IActionResult ViewHiddenNews()
        {
            return Ok();
        }
     
        [Authorize(Policy = "AdultNews")]
        [HttpGet, Route("view/AdultNews")]
        public IActionResult ViewAdultNews()
        {
            return Ok();
        }

    }
}
