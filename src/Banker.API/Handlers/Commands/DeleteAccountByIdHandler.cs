using Banker.API.Commands;

namespace Banker.API.Handlers.Commands;

public class DeleteAccountByIdHandler : IRequestHandler<DeleteAccountByIdCommand, IResult>
{
    private readonly IAccountRepository _accountRepository;
    private readonly ILogger<DeleteAccountByIdHandler> _logger;

    public DeleteAccountByIdHandler(IAccountRepository accountRepository, ILogger<DeleteAccountByIdHandler> logger)
    {
        _accountRepository = accountRepository;
        _logger = logger;
    }

    public async Task<IResult> Handle(DeleteAccountByIdCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var isDeleted = await _accountRepository.DeleteAccountAsync(request.Id);

            if (isDeleted == false)
            {
                _logger.LogInformation("Could not delete record with id: {id}", request.Id);

                var notDeletedResponse = new ResponseDto
                {
                    IsSuccessRequest = false,
                    Results = new object(),
                    Errors = new List<string>
                    {
                        "Could not delete the record"
                    }
                };

                return Results.BadRequest(notDeletedResponse);
            }

            var deletedResponse = new ResponseDto
            {
                IsSuccessRequest = true,
                Results = request.Id,
            };

            return Results.Ok(deletedResponse);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception,
                "The DELETE request for endpoint Api/Account with id of {id} was interrupted",
                request.Id);

            var badResponse = new ResponseDto
            {
                IsSuccessRequest = false,
                Results = new object(),
                Errors = new List<string>
                {
                    "The DELETE request was failed"
                }
            };

            return Results.BadRequest(badResponse);
        }
    }
}
