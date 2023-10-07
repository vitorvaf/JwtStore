
using Flunt.Notifications;
using Flunt.Validations;

namespace JwtStore.Core.Context.AccountContext.UseCases.Create;

public static class Specification 
{
    public static Contract<Notification> Ensure(Request request) 
    => new Contract<Notification>()
        .Requires()
        .IsNotNullOrEmpty(request.Name, nameof(request.Name), "Name is required")
        .IsLowerThan(request.Name.Length, 160, nameof(request.Name), "Name must be less than 160 characters")
        .IsGreaterThan(request.Name.Length, 3, nameof(request.Name), "Name must be greater than 3 characters")
        .IsNotNullOrEmpty(request.Email, nameof(request.Email), "Email is required")
        .IsNotNullOrEmpty(request.Password, nameof(request.Password), "Password is required")
        .IsLowerThan(request.Password.Length, 40, nameof(request.Password), "Password must be less than 40 characters")
        .IsGreaterThan(request.Password.Length, 8, nameof(request.Password), "Password must be greater than 8 characters")
        .IsEmail(request.Email, nameof(request.Email), "Email is invalid"); 
   
}
