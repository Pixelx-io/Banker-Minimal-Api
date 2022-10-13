namespace Banker.API.Handlers.Queries;

public class GetAccountByIdHandler : IRequestHandler<GetAccountByIdQuery, IResult>
{
    private readonly IAccountRepository _accountRepository;

    public GetAccountByIdHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<IResult> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
    {
        var modelFromDb = await _accountRepository
            .GetAccountByIdAsync(request.Id);

        var response = new ResponseDto
        {
            IsSuccessRequest = true,
            Results = modelFromDb,
            Errors = new List<string>()
        };

        return Results.Ok(response);
    }
}