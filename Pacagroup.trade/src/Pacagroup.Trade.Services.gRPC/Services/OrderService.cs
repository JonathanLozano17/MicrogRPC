using AutoMapper;
using Grpc.Core;
using MediatR;
using Pacagroup.Trade.Services.gRPC.Protos;


using Pacagroup.Trade.Application.UseCase.Features.Orders.Commands.CancelOrder;
using Pacagroup.Trade.Application.UseCase.Features.Orders.Commands.CreateOrder;
using Pacagroup.Trade.Application.UseCase.Features.Orders.Commands.UpdateOrder;
using Pacagroup.Trade.Application.UseCase.Features.Orders.Queries.GetAllOrder;
using Pacagroup.Trade.Application.UseCase.Features.Orders.Queries.GetOrder;
using Pacagroup.Trade.Domain.Entities;

namespace Pacagroup.Trade.Services.gRPC.Services
{
    public class OrderService : OrderServices.OrderServicesBase
    {
        public readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrderService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public override async Task<GetAllOrderResponse> GetAllOrder(GetAllOrderRequest getAllOrderRequest, ServerCallContext context)
        {
            var ordersDto = await _mediator.Send(new GetAllOrderQuery());
            var response = new GetAllOrderResponse();
            var serverResponse = new ServerResponse();



            // Verificar si ordersDto es del tipo correcto
            if (ordersDto.Any())
            {
                serverResponse.IsSuccess = true;
                serverResponse.Message = "Consulta exitosa!!";

                // Mapeamos correctamente los datos
                response.Data.AddRange(_mapper.Map<IEnumerable<OrderResponse>>(ordersDto));
            }
            else
                serverResponse.Message = "No se encontraron Ordenes!!";

            response.ServerResponse = serverResponse;


            return response;
        }

        public override async Task<GetOrderResponse> GetOrder(GetOrderRequest getOrderRequest, ServerCallContext context)
        {
            var orderDto = await _mediator.Send(new  GetOrderQuery() { Id = getOrderRequest.Id});
            var response = new GetOrderResponse();
            var serverResponse = new ServerResponse();

            if (orderDto == null)
            {
                serverResponse.Message = $"No se encontro la orden #: {getOrderRequest.Id}";
                return response;
            }

            response.Data = _mapper.Map<OrderResponse>(orderDto);
            serverResponse.IsSuccess= true;
            serverResponse.Message = "Consulta exitosa!!";

            response.ServerResponse = serverResponse;

            return response;

        }


        public override async Task<CreateOrderResponse> CreateOrder(CreateOrderRequest createOrderRequest, ServerCallContext context)
        {
            var createORderCommand = _mapper.Map<CreateOrderCommand>(createOrderRequest);
            var status = await _mediator.Send(createORderCommand);
            var response = new CreateOrderResponse();
            var serverResponse = new ServerResponse();

            if (status.Equals(true))
            {
                var orderDto = await _mediator.Send(new GetOrderQuery() { Id = createOrderRequest.Id });

                response.Data = _mapper.Map<OrderResponse>(orderDto);
                serverResponse.IsSuccess = true;
                serverResponse.Message = "Registro Exitoso!!";
            }
            else
                serverResponse.Message = $"Errores al creaar la orden #: {createOrderRequest.Id}";

            response.ServerResponse = serverResponse;

            return response;
        }


        public override async Task<UpdateOrderResponse> UpdateOrder(UpdateOrderRequest updateOrderRequest, ServerCallContext context)
        {
            var updateOrderCommand = _mapper.Map<UpdateOrderCommand>(updateOrderRequest);
            var status = await _mediator.Send(updateOrderCommand);
            var response = new UpdateOrderResponse();
            var serverResponse = new ServerResponse();

            if (status.Equals(true))
            {
                var orderDto = await _mediator.Send(new GetOrderQuery { Id = updateOrderRequest.Id });

                response.Data = _mapper.Map<OrderResponse>(orderDto);
                serverResponse.IsSuccess = true;
                serverResponse.Message = "Actualizacion Exitosa!!!";
            }
            else
                serverResponse.Message = $"Errores al actualziuar la orden #: {updateOrderRequest.Id} ";

            response.ServerResponse= serverResponse;

            return response;

        }


        public override async Task<CancelOrderResponse> CancelOrder(CancelOrderRequest cancelOrderRequest, ServerCallContext context)
        {
            var status = await _mediator.Send(new CancelOrderCommand { Id = cancelOrderRequest.Id });
            var response = new CancelOrderResponse();
            var serverResponse = new ServerResponse();

            if (status.Equals(true))
            {
                serverResponse.IsSuccess= true;
                serverResponse.Message = "Eliminacioon exitosa";
            }
            else
                serverResponse.Message = $"Errores al eliminar la orden #: {cancelOrderRequest.Id} ";


            response.ServerResponse= serverResponse;

            return response;

        }




    }
}
