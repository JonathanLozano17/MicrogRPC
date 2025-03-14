using MediatR;

namespace Pacagroup.Trade.Application.UseCase.Features.Orders.Commands.CancelOrder
{
    public sealed record CancelOrderCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
