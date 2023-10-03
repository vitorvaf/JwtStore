using JwtStore.Core.Context.AccountContext.Entites;
using JwtStore.Core.Context.AccountContext.UseCases.Create.Contracts;
using JwtStore.Core.Context.AccountContext.ValueObjects;

namespace JwtStore.Core.Context.AccountContext.UseCases.Create;

public class Handler

{
    private readonly IRepository _accountRepository;
    private readonly IService _accountService;

    public Handler(
        IRepository accountRepository,
        IService accountService
    )
    {
        _accountRepository = accountRepository;
        _accountService = accountService;
    }

    public async Task<Response> Handle(
        Request request,
        CancellationToken cancellationToken)
    {
        #region 01. Valida a requisição 

        try
        {
            var res = Specification.Ensure(request);
            if (!res.IsValid)
                return new Response("Requisição inválida", 400, res.Notifications);
        }
        catch
        {
            return new Response("Não foi posível validar sua requisição", 500);
        }

        #endregion

        #region 02. Cria os objetos de valor

        Email email;
        Password password;
        User user;

        try
        {
            email = new Email(request.Email);
            password = new Password(request.Password);
            user = new User(request.Name, email, password);
        }
        catch (Exception e)
        {
            return new Response(e.Message, 400);
        }
        #endregion

        #region 03. Verifica se o usuario já existe

        try
        {
            var userExist = await _accountRepository.AnyAsync(email, cancellationToken);
            if (userExist)
                return new Response("Este email já está em uso.", 400);

        }
        catch
        {
            return new Response("Não foi possível verificar se o usuário já existe.", 500);
        }

        #endregion

        #region 04. Persiste os dados

        try
        {
            await _accountRepository.CreateAsync(user, cancellationToken);
        }
        catch
        {
            return new Response("Não foi possível criar o usuário.", 500);
        }

        #endregion

        #region 05. Envia o email de confirmação

        try
        {
            await _accountService.SendConfirmationEmailAsync(user, cancellationToken);
        }
        catch
        {
            return new Response("Não foi possível enviar o email de confirmação.", 500);
        }

        #endregion

        return new Response(
            message: "Usuário criado com sucesso.", 
            new ResponseData(user.Id, user.Name, user.Email)
        );
    }
}