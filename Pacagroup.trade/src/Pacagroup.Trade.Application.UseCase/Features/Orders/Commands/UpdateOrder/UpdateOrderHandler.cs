using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pacagroup.Trade.Application.Interface.Persistence;

namespace Pacagroup.Trade.Application.UseCase.Features.Orders.Commands.UpdateOrder
{
    internal class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, bool>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public UpdateOrderHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _applicationDbContext.Orders.FirstOrDefaultAsync(x => x.Id.Equals(request.Id), cancellationToken);

            if (order is not null)
            {
                order.Quanty = request.Quanty;
                order.Type = (Domain.Enums.OrderType)request.Type;
                order.Price = request.Price;
                order.Text = order.Text;

                _applicationDbContext.Orders.Update(order);

            }

            if (await _applicationDbContext.SaveChangesAsync(cancellationToken) > 0)
                return true;
            else
                return false;
        }
    }
}
