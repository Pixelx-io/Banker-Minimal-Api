using Banker.API.Commands;

namespace Banker.API.Handlers.Commands;

public class UpdateAccountHandler : IRequestHandler<UpdateAccountCommand, IResult>
{
    private readonly IAccountRepository _accountRepository;
    private readonly ILogger<UpdateAccountHandler> _logger;

    public UpdateAccountHandler(IAccountRepository accountRepository, ILogger<UpdateAccountHandler> logger)
    {
        _accountRepository = accountRepository;
        _logger = logger;
    }

    public async Task<IResult> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
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

            var responseFromDb = await _accountRepository.UpdateAccountAsync(request.Account);

            if (responseFromDb is null)
            {
                var badResponse = new ResponseDto
                {
                    IsSuccessRequest = false,
                    Results = new object(),
                    Errors = new List<string>()
                    {
                        "Something went wrong, could not update data"
                    }
                };

                return Results.BadRequest(badResponse);
            }

            var updatedResponse = new ResponseDto
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
                "The UPDATE request for endpoint Api/Account was failed");

            var badResponse = new ResponseDto
            {
                IsSuccessRequest = false,
                Results = new object(),
                Errors = new List<string>
                {
                    "The UPDATE request was failed"
                }
            };

            return Results.BadRequest(badResponse);
        }
    }
}
