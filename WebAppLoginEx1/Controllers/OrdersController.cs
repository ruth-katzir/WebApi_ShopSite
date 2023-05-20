using AutoMapper;
using DTO;
using entities;
using Microsoft.AspNetCore.Mvc;
using Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppLoginEx1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrderService service;
        IMapper mapper;

        public OrdersController(IOrderService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }


        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public async Task<OrderDTO> Get(int id)
        {
            Order order = await service.getOrderAsync(id);
            OrderDTO orderDTO = mapper.Map<Order, OrderDTO>(order);
            return orderDTO;
        }

        // POST api/<OrdersController>
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> Post([FromBody] OrderDTO orderDTO)
        {
            Order order = mapper.Map<OrderDTO, Order>(orderDTO);
            Order orderCreated = await service.addOrderAsync(order);
            if (orderCreated != null)
            {
                OrderDTO orderCreatedDTO = mapper.Map<Order, OrderDTO>(orderCreated);
                return CreatedAtAction(nameof(Get), new { id = orderCreatedDTO.Id }, orderCreatedDTO);
            }
            return BadRequest();
        }


    }
}
