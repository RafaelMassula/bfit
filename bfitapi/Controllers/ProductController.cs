using bfitapi.Data.IServices;
using bfitapi.Exceptions;
using bfitapi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bfitapi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;
        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }
        [Route("products"), HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
                return (IActionResult)Task.FromResult(product);
            try
            {
                return Created("", await _repository.Create(product));
            }
            catch (DbUpdateException error)
            {
                return BadRequest(error.Message);
            }
        }

        [Route("products/{id}"), HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await _repository.Delete(id);
                return NoContent();
            }
            catch (DbUpdateException error)
            {
                return BadRequest(error.Message);
            }
            catch (KeyNotFoundException error)
            {
                return NotFound(error.Message);
            }
        }

        [Route("products/{id}"), HttpGet]
        public async Task<IActionResult> GetProductsForId(int id)
        {
            try
            {
                var product = await _repository.Get(id);
                return Ok(product);
            }
            catch (KeyNotFoundException error)
            {
                return NotFound(error.Message);
            }
        }

        [Route("products"), HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _repository.GetList();
            return Ok(products);
        }

        [Route("products"), HttpPut]
        public async Task<IActionResult> UpdateTypePayment([FromBody] Product product)
        {
            try
            {
                return Ok(await _repository.Update(product));
            }
            catch (DbUpdateException error)
            {
                return BadRequest(error.Message);
            }
            catch (KeyNotFoundException error)
            {
                return NotFound(error.Message);
            }
        }
    }
}
