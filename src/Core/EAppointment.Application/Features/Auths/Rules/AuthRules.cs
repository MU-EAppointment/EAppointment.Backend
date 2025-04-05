using EAppointment.Application.Commons.Exceptions;
using EAppointment.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EAppointment.Application.Features.Auths.Rules
{
    internal record AuthRules(UserManager<User> UserManager)
    {
        internal async Task<User> UserNotFound(string emailOrUsername, CancellationToken cancellationToken)
        {
            User? user = await UserManager.Users.FirstOrDefaultAsync(u => u.UserName == emailOrUsername || u.Email == emailOrUsername, cancellationToken);
            return user ?? throw new BaseException(AuthErrorType.UserNotFound, HttpStatusCode.NotFound);
        }

        internal async Task IsPasswordCorrect(User user, string password)
        {
            bool data = await UserManager.CheckPasswordAsync(user, password);
            if (data is false) throw new BaseException(AuthErrorType.PasswordNotCorrect, HttpStatusCode.NotFound);
        }
    }
}
