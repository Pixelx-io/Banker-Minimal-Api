using Banker.API.Commands;

namespace Banker.API.Handlers.Commands;

public class InsertAccountHandler : IRequestHandler<InsertAccountCommand, IResult>
{
    private readonly IAccountRepository _accountRepository;
    private readonly ILogger<InsertAccountHandler> _logger;

    public InsertAccountHandler(IAccountRepository accountRepository, ILogger<InsertAccountHandler> logger)
    {
        _accountRepository = accountRepository;
        _logger = logger;
    }

    public async Task<IResult> Handle(InsertAccountCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request.Account is null)
            {
                var badResponse = new ResponseDto
                {
                    IsSuccessRequest = false,
                    Results = new object(),
                    Errors = new List<string>()
                    {
                        "Invalid data entry"
                    }
                };

                return Results.BadRequest(badResponse);
            }

            var responseFromDb = await _accountRepository.CreateAccountAsync(request.Account);

            if (responseFromDb is null)
            {
                var badResponse = new ResponseDto
                {
                    IsSuccessRequest = false,
                    Results = new object(),
                    Errors = new List<string>()
                    {
                        "Something went wrong, could not insert data"
                    }
                };

                return Results.BadRequest(badResponse);
            }

            var createdResponse = new ResponseDto
            {
                IsSuccessRequest = false,
                Results = responseFromDb,
                Errors = new List<string>()
            };

            return Results.Ok();
        }
        catch (Exception exception)
        {
            _logger.LogError(exception,
                "The INSERT request for endpoint Api/Account was failed");

            var badResponse = new ResponseDto
            {
                IsSuccessRequest = false,
                Results = new object(),
                Errors = new List<string>
                {
                    "The INSERT request was failed"
                }
            };

            return Results.BadRequest(badResponse);
        }
    }
}
