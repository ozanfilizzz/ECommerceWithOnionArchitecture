using Application.Repositories;
using Domain.Entites.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly IOrderReadRepository _orderReadRepository;

        public TestController(IOrderWriteRepository orderWriteRepository, IOrderReadRepository orderReadRepository)
        {
            _orderWriteRepository = orderWriteRepository;
            _orderReadRepository = orderReadRepository;
        }

        [HttpGet]
        public async Task Get()
        {
           Order order = await _orderReadRepository.GetByIdAsync("f4084614-dcb9-435e-9b65-9340a9e05cfa");

            order.Description = "Description";

            await _orderWriteRepository.SaveAsync();
        }

    }
}
