using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pacagroup.Trade.Application.Interface.Persistence;

namespace Pacagroup.Trade.Application.UseCase.Features.Orders.Queries.GetAllOrder
{
    internal class GetAllOrderHandler : IRequestHandler<GetAllOrderQuery, IEnumerable<GetAllOrderResponseDto>>
    {

        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public GetAllOrderHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllOrderResponseDto>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
        {
            var orders = await _applicationDbContext.Orders.ToListAsync(cancellationToken);
            var response = _mapper.Map<IEnumerable<GetAllOrderResponseDto>>(orders);

            return response;
        
        }
    }
}
