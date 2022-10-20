namespace Banker.API.Commands;

public record InsertAccountCommand(AccountDto Account) : IHttpRequest;