namespace Banker.API.Commands;

public record UpdateAccountCommand(AccountDto Account) : IHttpRequest;