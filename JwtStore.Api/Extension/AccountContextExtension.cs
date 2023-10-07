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

    }


}