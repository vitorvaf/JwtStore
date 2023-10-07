using MediatR;

namespace JwtStore.Core.Context.AccountContext.UseCases;

public record Request(
    string Name, 
    string Email, 
    string Password
): IRequest<Response>;

    