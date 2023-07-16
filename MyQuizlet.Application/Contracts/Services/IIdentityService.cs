using Microsoft.AspNetCore.Identity;
using MyQuizlet.Application.DTO;

namespace MyQuizlet.Application.Contracts.Services
{
    public interface IIdentityService
    {
        public Task<SignInResult> SignInAsync(SignInDto signInDto);
        public Task<IdentityResult> SignUpAsync(SignUpDto signUpDto);
        public Task SignOutAsync();
    }
}
