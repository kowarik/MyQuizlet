using Microsoft.AspNetCore.Identity;
using MyQuizlet.Application.Contracts.Services;
using MyQuizlet.Application.DTO;
using MyQuizlet.Application.Enums;

namespace MyQuizlet.Infrastructure.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public IdentityService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> SignUpAsync(SignUpDto signUpDto)
        {
            if (await _userManager.FindByEmailAsync(signUpDto.Email) == null)
            {
                var user = new IdentityUser { Email = signUpDto.Email, UserName = signUpDto.Email };
                var result = await _userManager.CreateAsync(user, signUpDto.Password);

                if (!await _roleManager.RoleExistsAsync(signUpDto.Role.ToString()))
                {
                    var role = new IdentityRole { Name = signUpDto.Role.ToString() };
                    var roleAddResult = await _roleManager.CreateAsync(role);
                    if (!roleAddResult.Succeeded)
                    {
                        return IdentityResult.Failed(new IdentityError { Description = "Failed to create User Role" });
                    }
                }

                var addUserRoleResult = await _userManager.AddToRoleAsync(user, signUpDto.Role.ToString());
                if (!addUserRoleResult.Succeeded)
                {
                    return IdentityResult.Failed(new IdentityError { Description = "Failed to create User with this Role" });
                }

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                }
                return result;
            }
            else
            {
                return IdentityResult.Failed(new IdentityError { Description = "User already registered" });
            }
        }

        public async Task<SignInResult> SignInAsync(SignInDto signInDto)
        {
            var result = await _signInManager.PasswordSignInAsync(signInDto.Email, signInDto.Password, signInDto.RememberMe, lockoutOnFailure: false);
            return result;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
