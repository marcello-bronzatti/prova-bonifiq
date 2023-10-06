﻿using Microsoft.AspNetCore.Mvc;
using ProvaPub.Models;
using ProvaPub.Services;

namespace ProvaPub.Controllers
{

    /// <summary>
    /// Esse teste simula um pagamento de uma compra.
    /// O método PayOrder aceita diversas formas de pagamento. Dentro desse método é feita uma estrutura de diversos "if" para cada um deles.
    /// Sabemos, no entanto, que esse formato não é adequado, em especial para futuras inclusões de formas de pagamento.
    /// Como você reestruturaria o método PayOrder para que ele ficasse mais aderente com as boas práticas de arquitetura de sistemas?
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class Parte3Controller : ControllerBase
    {
        private readonly OrderService _orderService;
        private readonly IPaymentService _paymentService;

        public Parte3Controller(IPaymentService paymentService, OrderService orderService)
        {
            _orderService = orderService;
            _paymentService = paymentService;
        }

        [HttpPost("orders")]
        public async Task<Order> PlaceOrder(string paymentMethod, decimal paymentValue, int customerId) 
        {

            var paymentClass = _paymentService.CreatePaymentClass(paymentMethod);
            return await _orderService.PayOrder(paymentClass, paymentValue, customerId);
        }
    }
}
