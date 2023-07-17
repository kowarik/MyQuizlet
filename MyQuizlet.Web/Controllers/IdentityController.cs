using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyQuizlet.Application.Contracts.Services;
using MyQuizlet.Application.DTO;

namespace MyQuizlet.Web.Controllers
{
    [Controller]
    [Route("[controller]")]
    [AllowAnonymous]
    public class IdentityController : Controller
    {
        private readonly IIdentityService _identityService;
        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpGet("[action]")]
        public IActionResult SignUp()
        {
            var model = new SignUpDto();
            return View(model);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SignUp(SignUpDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _identityService.SignUpAsync(model);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("SignUp", error.Description);
                    }
                }
            }

            return View(model);
        }

        [HttpGet("[action]")]
        public IActionResult SignIn()
        {
            var model = new SignInDto();
            return View(model);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SignIn(SignInDto model, string? ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _identityService.SignInAsync(model);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
                    {
                        return LocalRedirect(ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("SignIn", "Invalid email or password");
                }
            }

            return View(model);
        }

        public async Task<IActionResult> SignOut()
        {
            await _identityService.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> AccessDenied()
        {
            return View();
        }
    }
}
