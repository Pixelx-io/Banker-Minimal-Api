namespace Banker.API.Commands;

public record DeleteAccountByIdCommand(int Id) : IHttpRequest;