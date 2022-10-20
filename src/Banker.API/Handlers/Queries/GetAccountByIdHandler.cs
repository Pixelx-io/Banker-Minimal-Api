namespace Banker.API.Handlers.Queries;

public class GetAccountByIdHandler : IRequestHandler<GetAccountByIdQuery, IResult>
{
    private readonly IAccountRepository _accountRepository;
    private readonly ILogger<GetAccountByIdHandler> _logger;

    public GetAccountByIdHandler(IAccountRepository accountRepository, ILogger<GetAccountByIdHandler> logger)
    {
        _accountRepository = accountRepository;
        _logger = logger;
    }

    /// <summary>
    /// Gets the list of all records
    /// </summary>
    /// <returns></returns>
    public async Task<IResult> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var modelFromDb = await _accountRepository
                .GetAccountByIdAsync(request.Id);

            if (modelFromDb is null)
            {
                _logger.LogInformation("There is no record found for the request of id: {id}", request.Id);

                var emptyResponse = new ResponseDto
                {
                    IsSuccessRequest = false,
                    Results = new object(),
                    Errors = new List<string>
                    {
                        "There is no record for this request"
                    }
                };

                return Results.NotFound(emptyResponse);
            }

            var response = new ResponseDto
            {
                IsSuccessRequest = true,
                Results = modelFromDb,
                Errors = new List<string>()
            };

            return Results.Ok(response);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception,
                "The Get request for endpoint Api/Account with id of {id} was interrupted",
                request.Id);

            var badResponse = new ResponseDto
            {
                IsSuccessRequest = false,
                Results = new object(),
                Errors = new List<string>
                {
                    "The request was failed"
                }
            };

            return Results.BadRequest(badResponse);
        }
    }
}