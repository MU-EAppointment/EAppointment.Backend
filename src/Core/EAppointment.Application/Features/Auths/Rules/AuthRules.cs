using EAppointment.Application.Commons.Exceptions;
using EAppointment.Application.Commons.Results;
using EAppointment.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EAppointment.Application.Features.Auths.Rules
{
    internal readonly struct AuthRules(UserManager<User> _userManager)
    {
        internal async Task<User> UserNotFound(string emailOrUsername, CancellationToken cancellationToken)
        {
            User? user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == emailOrUsername || u.Email == emailOrUsername, cancellationToken);
            return user ?? throw new BaseException(AuthErrorType.UserNotFound, HttpStatusCode.NotFound);
        }

        internal async Task IsPasswordCorrect(User user, string password)
        {
            bool data = await _userManager.CheckPasswordAsync(user, password);
            if (data is false) throw new BaseException(AuthErrorType.PasswordNotCorrect, HttpStatusCode.NotFound);
        }
    }
}
