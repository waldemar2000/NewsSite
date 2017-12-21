using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsSite.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;

namespace NewsSite.Controllers
{
    [Route("api/Seed")]
    public class UserController : Controller
    {
        private UserManager<ApplicationUser> userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }


        [HttpGet]
        async public Task<IActionResult> SeedUsers()
        {
            var allUsers = userManager.Users.ToList();

            foreach (var x in allUsers)
            {
                await userManager.DeleteAsync(x);
            }
            ApplicationUser adam = new ApplicationUser { UserName = "adam", Email = "adam@gmail.com" };           
            ApplicationUser viktor = new ApplicationUser { UserName = "viktor", Email = "viktor@gmail.com" };
            ApplicationUser susan = new ApplicationUser { UserName = "susan", Email = "susan@gmail.com" };
            ApplicationUser peter = new ApplicationUser { UserName = "peter", Email = "peter@gmail.com" };
            ApplicationUser xerxes = new ApplicationUser { UserName = "xerxes", Email = "xerxes@gmail.com" };
            await userManager.CreateAsync(adam);
            await userManager.AddClaimAsync(adam, new System.Security.Claims.Claim("role","administrator"));

            await userManager.CreateAsync(viktor);
            await userManager.AddClaimAsync(viktor, new System.Security.Claims.Claim("role", "subscriber"));
            await userManager.AddClaimAsync(viktor, new System.Security.Claims.Claim("age", "15"));


            await userManager.CreateAsync(susan);
            await userManager.AddClaimAsync(susan, new System.Security.Claims.Claim("role", "subscriber"));
            await userManager.AddClaimAsync(susan, new System.Security.Claims.Claim( "age", "48"));

            await userManager.CreateAsync(peter);
            await userManager.AddClaimAsync(peter, new System.Security.Claims.Claim("role", "publisher"));

            await userManager.CreateAsync(xerxes);
            //await userManager.AddClaimAsync(xerxes, new System.Security.Claims.Claim("role", "administrator"));
            

            //List<ApplicationUser> userList = new List<ApplicationUser>()
            //{
            //  new ApplicationUser {UserName="adam", Email="adam@gmail.com"},
            //  new ApplicationUser {UserName="victor", Email="victor@gmail.com"},
            //  new ApplicationUser {UserName="susan", Email="susan@gmail.com"},
            //  new ApplicationUser {UserName="peter", Email="peter@gmail.com"},
            //  new ApplicationUser {UserName="xerxes", Email="xerxes@gmail.com"}
            //};
            //foreach (ApplicationUser applicationUser in userList)
            //{
            //    await userManager.CreateAsync(applicationUser);
            //}

            // Skapa användare med userManager...

            return Ok();
            /*
            foreach (ApplicationUser applicationUser in databaseContext.Users)
            {
                databaseContext.Remove(applicationUser);
            }

            List<ApplicationUser> userList = new List<ApplicationUser>()
            {
              new ApplicationUser {UserName="adam2", Email="adam2@gmail.com"},
              new ApplicationUser {UserName="victor", Email="victor@gmail.com"},
              new ApplicationUser {UserName="susan", Email="susan@gmail.com"},
              new ApplicationUser {UserName="peter", Email="peter@gmail.com"},
              new ApplicationUser {UserName="xerxes", Email="xerxes@gmail.com"}
            };
            foreach (ApplicationUser applicationUser in userList)
            {
                databaseContext.Add(applicationUser);
            }
            databaseContext.SaveChanges();
            return Ok("hej");
            */
        }
    }
}