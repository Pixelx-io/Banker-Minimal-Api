using Banker.API.Requests;

namespace Banker.API.Queries;

public record GetAccountByIdQuery(int Id) : IHttpRequest;