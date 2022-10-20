namespace Banker.API.Handlers.Queries;

public class GetAccountsHandler : IRequestHandler<GetAccountsQuery, IResult>
{
    private readonly IAccountRepository _accountRepository;
    private readonly ILogger<GetAccountsHandler> _logger;

    public GetAccountsHandler(IAccountRepository accountRepository, ILogger<GetAccountsHandler> logger)
    {
        _accountRepository = accountRepository;
        _logger = logger;
    }

    public async Task<IResult> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var modelsFromDb = await _accountRepository.GetAccountsAsync();

            if (!modelsFromDb.Any())
            {
                _logger.LogInformation("There are no records for this request");

                var notFoundResponse = new ResponseDto
                {
                    IsSuccessRequest = false,
                    Results = new object(),
                    Errors = new List<string>
                    {
                        "There are no records"
                    }
                };

                return Results.NotFound(notFoundResponse);
            }

            var response = new ResponseDto
            {
                IsSuccessRequest = true,
                Results = modelsFromDb,
                Errors = new List<string>()
            };

            return Results.Ok(response);
        }
        catch (Exception exception)
        {
            var badResponse = new ResponseDto
            {
                IsSuccessRequest = false,
                Results = new object(),
                Errors = new List<string>
                {
                    "The request was failed"
                }
            };

            return Results.NotFound(badResponse);
        }
    }
}
