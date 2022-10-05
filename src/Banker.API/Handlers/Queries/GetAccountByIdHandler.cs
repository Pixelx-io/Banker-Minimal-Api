namespace Banker.API.Handlers.Queries;

public class GetAccountByIdHandler : IRequestHandler<GetAccountByIdQuery, IResult>
{
    private readonly IAccountManager _accountManager;

    public GetAccountByIdHandler(IAccountManager accountManager)
    {
        _accountManager = accountManager;
    }
    public async Task<IResult> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
    {
        var modelFromDb = await _accountManager.GetAccountByIdAsync(request.Id);

        var response = new ResponseDto
        {
            IsSuccessRequest = true,
            Results = modelFromDb,
            Errors = new List<string>()
        };

        return Results.Ok(response);
    }
}