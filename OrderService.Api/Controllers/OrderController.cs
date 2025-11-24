using Microsoft.AspNetCore.Mvc;
using OrderService.Application.Interfaces;

namespace OrderService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class OrderController : ControllerBase
    {

        private readonly IOrderService _service;

        //public OrderController(IOrderService service)
        //{
        //    _service = service;
        //}
    }
}
