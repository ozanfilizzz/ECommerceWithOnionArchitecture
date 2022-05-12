using Application.Repositories;
using Application.ViewModels.Products;
using Domain.Entites.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public TestController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_productReadRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _productReadRepository.GetByIdAsync(id, false));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProduct createProduct)
        {
            await _productWriteRepository.AddAsync(new()
            {
                Name = createProduct.Name,
                Price = createProduct.Price,
                UnitInStock = createProduct.UnitInStock,
                Description = createProduct.Description

            });
            await _productWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProduct updateProduct)
        {
            Product product = await _productReadRepository.GetByIdAsync(updateProduct.Id);
            product.Name = updateProduct.Name;
            product.Price = updateProduct.Price;
            product.UnitInStock = updateProduct.UnitInStock;

            await _productWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveAsync();
            return Ok();
        }

    }
}
