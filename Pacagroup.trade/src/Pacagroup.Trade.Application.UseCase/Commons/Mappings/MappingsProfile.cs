using AutoMapper;
using Pacagroup.Trade.Application.UseCase.Features.Orders.Commands.CreateOrder;
using Pacagroup.Trade.Application.UseCase.Features.Orders.Commands.UpdateOrder;
using Pacagroup.Trade.Application.UseCase.Features.Orders.Queries.GetAllOrder;
using Pacagroup.Trade.Application.UseCase.Features.Orders.Queries.GetOrder;
using Pacagroup.Trade.Domain.Entities;

namespace Pacagroup.Trade.Application.UseCase.Commons.Mappings
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<CreateOrderCommand, Order>().ReverseMap();
            CreateMap<UpdateOrderCommand, Order>().ReverseMap();
            CreateMap<GetOrderResponseDto, Order>().ReverseMap();
            CreateMap<GetAllOrderResponseDto, Order>().ReverseMap();

        }
    }
}
