using BookStore.Server.Controllers;
using BookStore.Server.Data.Models;
using BookStore.Server.Features.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BookStore.Server.Features.Identity
{
    public class IdentityController : ApiController
    {
        private readonly UserManager<User> userManager;
        private readonly IIdentityService identityService;
        private readonly AppSettings appSettings;

        public IdentityController(
            UserManager<User> userManager,
            IOptions<AppSettings> appSettings,
            IIdentityService identityService)
        {
            this.userManager = userManager;
            this.identityService = identityService;
            this.appSettings = appSettings.Value;
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(RegisterRequestModel model)
        {
            var user = new User()
            {
                UserName = model.UserName,
                Email = model.Email,
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginTokenModel>> Login(LoginRequestModel model)
        {
            var user = await userManager.FindByNameAsync(model.UserName);

            if (user == null)
            {
                return Unauthorized();
            }

            var validPassword = await userManager.CheckPasswordAsync(user, model.Password);

            if (!validPassword)
            {
                return Unauthorized();
            }

            var token = this.identityService.GenerateJwtToken(
                user.Id,
                user.UserName,
                appSettings.Secret);

            return new LoginTokenModel
            {
                Token = token
            };
        }
    }
}
