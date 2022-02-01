using bfitapi.Data.IServices;
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
    public class AddressController: ControllerBase
    {
        private readonly IAddressRepository _repository;
        public AddressController(IAddressRepository repository)
        {
            _repository = repository;
        }

        [Route("addresses"), HttpPost]
        public async Task<IActionResult> CreateAdress([FromBody] Address adress)
        {
            if (!ModelState.IsValid)
                return (IActionResult)Task.FromResult(adress);
            try
            {
                await _repository.Create(adress);
                return Created("", adress);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [Route("addresses/{id}"), HttpDelete]
        public async Task<IActionResult> DeleteAdress4(int id)
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


        [Route("adress/{id}"), HttpGet]
        public async Task<IActionResult> GetAdressForId(int id)
        {
            try
            {
                var adress = await _repository.Get(id);
                return Ok(adress);
            }
            catch (KeyNotFoundException error)
            {
                return NotFound(error.Message);
            }
        }

        [Route("addresses"), HttpGet]
        public async Task<IActionResult> GetAddresses()
        {
            var addresses = await _repository.GetList();
            return Ok(addresses);
        }

        [Route("addresses"), HttpPut]
        public async Task<IActionResult> UpdateAddresses([FromBody] Address address)
        {
            try
            {
                return Ok(await _repository.Update(address));
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
