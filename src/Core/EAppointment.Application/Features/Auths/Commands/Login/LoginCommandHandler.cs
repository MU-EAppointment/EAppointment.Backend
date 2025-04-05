using EAppointment.Application.Abstractions.Services;
using EAppointment.Application.Commons.Results;
using EAppointment.Application.Features.Auths.DTOs;
using EAppointment.Application.Features.Auths.Rules;
using EAppointment.Domain.Entities;
using Mediator;

namespace EAppointment.Application.Features.Auths.Commands.Login
{
    public readonly record struct LoginCommandRequest(string UsernameOrEmail, string Password) : IRequest<Result<LoginUserDTO>>;
    internal sealed class LoginCommandHandler(AuthRules _authRule, IJwtTokenHandler _jwtTokenHandler) : IRequestHandler<LoginCommandRequest, Result<LoginUserDTO>>
    {
        public async ValueTask<Result<LoginUserDTO>> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            User? user = await _authRule.UserNotFound(request.UsernameOrEmail, cancellationToken);
            await _authRule.IsPasswordCorrect(user, request.Password);
            return Result<LoginUserDTO>.Success(new(_jwtTokenHandler.CreateToken(user)));
        }
    }
}
