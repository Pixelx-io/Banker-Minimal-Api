using MediatR;

namespace Banker.API.Requests;

public interface IHttpRequest : IRequest<IResult>
{
}