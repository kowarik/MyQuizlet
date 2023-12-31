﻿using Microsoft.AspNetCore.Identity;
using MyQuizlet.Application.Contracts.Services;
using MyQuizlet.Application.DTO;
using MyQuizlet.Domain.IdentityEntities;

namespace MyQuizlet.Application.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public IdentityService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> SignUpAsync(SignUpDto signUpDto)
        {
            if (await _userManager.FindByEmailAsync(signUpDto.Email) == null)
            {
                var user = new ApplicationUser { Email = signUpDto.Email, UserName = signUpDto.Email };
                var result = await _userManager.CreateAsync(user, signUpDto.Password);

                if (!await _roleManager.RoleExistsAsync(signUpDto.Role.ToString()))
                {
                    var role = new ApplicationRole { Name = signUpDto.Role.ToString() };
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
