using AutoMapper;
using Google.Protobuf.WellKnownTypes;

using Pacagroup.Trade.Application.UseCase.Features.Orders.Commands.CreateOrder;
using Pacagroup.Trade.Application.UseCase.Features.Orders.Commands.UpdateOrder;
using Pacagroup.Trade.Application.UseCase.Features.Orders.Queries.GetOrder;
using Pacagroup.Trade.Application.UseCase.Features.Orders.Queries.GetAllOrder;
using Pacagroup.Trade.Services.gRPC.Protos;

namespace Pacagroup.Trade.Services.gRPC.Commons.Mappings
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {

            CreateMap<DateTime, Timestamp>()
                .ConvertUsing(x => Timestamp.FromDateTime(DateTime.SpecifyKind(x, DateTimeKind.Utc)));

            CreateMap<Timestamp, DateTime>()
                .ConvertUsing(x => x.ToDateTime());

            CreateMap<CreateOrderCommand, CreateOrderRequest>().ReverseMap();
            CreateMap<UpdateOrderCommand, UpdateOrderRequest>().ReverseMap();
            CreateMap<OrderResponse, GetOrderResponseDto>().ReverseMap();
            CreateMap<OrderResponse, GetAllOrderResponseDto>().ReverseMap();
        }
    }
}
