    using MediatR;

    namespace Pacagroup.Trade.Application.UseCase.Features.Orders.Queries.GetAllOrder
    {
        public sealed record GetAllOrderQuery : IRequest<IEnumerable<GetAllOrderResponseDto>>
        {
        }
    }
