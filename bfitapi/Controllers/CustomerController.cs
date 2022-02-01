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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repository;

        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        [Route("customers"), HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
                return (IActionResult)Task.FromResult(customer);
            try
            {
                await _repository.Create(customer);
                return Created("", customer);
            }
            catch (BirthDateException error)
            {
                return BadRequest(error.Message);
            }
            catch (CpfException error)
            {
                return BadRequest(error.Message);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [Route("customers/{id}"), HttpDelete]
        public async Task<IActionResult> DeleteCustomer(int id)
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

        [Route("customers/{id}"), HttpGet]
        public async Task<IActionResult> GetCustomerForId(int id)
        {
            try
            {
                var customer = await _repository.Get(id);
                return Ok(customer);
            }
            catch (KeyNotFoundException error)
            {
                return NotFound(error.Message);
            }
        }

        [Route("customers"), HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _repository.GetList();
            return Ok(customers);
        }

        [Route("customers"), HttpPut]
        public async Task<IActionResult> UpdateCustomer([FromBody] Customer customer)
        {
            try
            {
                return Ok(await _repository.Update(customer));
            }
            catch (DbUpdateException error)
            {
                return BadRequest(error.Message);
            }
            catch (KeyNotFoundException error)
            {
                return NotFound(error.Message);
            }
            catch (BirthDateException error)
            {
                return BadRequest(error.Message);
            }
            catch (CpfException error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
