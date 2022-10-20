using Banker.API.Commands;
using Banker.API.Handlers.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Banker.API.Extensions;

public static class EndpointsExtension
{
    public static WebApplication MapAccountEndpoints(this WebApplication app)
    {
        var logger = app.Logger;

        // @Route        : /Api/Account/{id}
        // @Description  : Gets an account by user id
        // @Authorization: Anonymous
        app.MapGet("/Api/Account/{id}", async ([FromServices] IMediator mediator, int id) =>
            {
                logger.LogInformation("GET: Api/Account/{id}", id);

                return await mediator.Send(new GetAccountByIdQuery(id));
            })
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .WithSummary("Get's a list")
            .WithDescription("Something good")
            .WithOpenApi();

        // @Route        : /Api/Account
        // @Description  : Gets a list of accounts
        // @Authorization: Anonymous
        app.MapGet("/Api/Account", async ([FromServices] IMediator mediator) =>
            {
                logger.LogInformation("GET: Api/Account");

                return await mediator.Send(new GetAccountsQuery());
            })
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .WithSummary("Get's a list")
            .WithDescription("Something good")
            .WithOpenApi();

        // @Route        : /Api/Account
        // @Description  : Creates an account
        // @Authorization: Anonymous
        app.MapPost("/Api/Account", async ([FromServices] IMediator mediator, [FromBody] AccountDto accountDto) =>
            {
                logger.LogInformation("INSERT: Api/Account");

                return await mediator.Send(new InsertAccountCommand(accountDto));
            })
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .WithSummary("Creates an account")
            .WithDescription("Creates an account from account dto ")
            .WithOpenApi();

        // @Route        : /Api/Account
        // @Description  : Updates an account
        // @Authorization: Anonymous
        app.MapPut("/Api/Account", async ([FromServices] IMediator mediator, [FromBody] AccountDto accountDto) =>
            {
                logger.LogInformation("UPDATE: Api/Account");

                return await mediator.Send(new UpdateAccountCommand(accountDto));
            })
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .WithSummary("Updates an account")
            .WithDescription("Updates an account from account dto ")
            .WithOpenApi();

        // @Route        : /Api/Account
        // @Description  : Deletes an account
        // @Authorization: Anonymous
        app.MapDelete("/Api/Account/{id}", async ([FromServices] IMediator mediator, int id) =>
            {
                logger.LogInformation("DELETE: Api/Account/{id}", id);

                return await mediator.Send(new DeleteAccountByIdCommand(id));
            })
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .WithSummary("Deletes an account")
            .WithDescription("Deletes an account from account dto ")
            .WithOpenApi();

        return app;
    }
}
