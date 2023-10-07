using MediatR;

namespace JwtStore.Api.Extension;

public static class AccountContextExtension
{
    public static void AddAcountContex(this WebApplicationBuilder builder)
    {
        #region Create

        builder.Services.AddTransient<
            JwtStore.Core.Context.AccountContext.UseCases.Create.Contracts.IRepository,
            JwtStore.Infra.Context.AccountContext.UserCases.Create.Repository
        >();

        builder.Services.AddTransient<
            JwtStore.Core.Context.AccountContext.UseCases.Create.Contracts.IService,
            JwtStore.Infra.Context.AccountContext.UserCases.Create.Service
        >();

        #endregion

    }

    public static void AddAcountEndpoints(this WebApplication app)
    {
        #region Create
        app.MapPost("api/v1/users", async (JwtStore.Core.Context.AccountContext.UseCases.Create.Request request,
        IRequestHandler<
            JwtStore.Core.Context.AccountContext.UseCases.Create.Request,
            JwtStore.Core.Context.AccountContext.UseCases.Create.Response> handler
        ) =>
        {
           var response = await handler.Handle(request, new CancellationToken()); 
           return response.IsSuccess
                ? Results.Created("", response)
                : Results.BadRequest(response);     

        });

        #endregion

    }


}