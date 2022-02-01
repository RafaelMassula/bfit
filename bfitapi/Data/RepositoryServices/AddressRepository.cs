using bfitapi.Data.IServices;
using bfitapi.Data.Services;
using bfitapi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bfitapi.Data.RepositoryServices
{
    public class AddressRepository : IAddressRepository
    {
        private readonly BfitContext _context;

        public AddressRepository(BfitContext context)
        {
            _context = context;
        }
        public async Task<Address> Create(Address adress)
        {
            try
            {
                adress.ZipCod = AddressesServices.GetZipCod(adress.ZipCod);
                _context.Addresses.Add(adress);
                await _context.SaveChangesAsync();

                return await Get(adress.Id);
            }
            catch (DbUpdateException error)
            {
                throw new DbUpdateException(error.Message);
            }
        }

        public async Task<Address> Delete(int key)
        {
            var adress = await Get(key);

            try
            {
                _context.Addresses.Remove(adress);
                await _context.SaveChangesAsync();
                return adress;
            }
            catch (DbUpdateException error)
            {
                throw new DbUpdateException(error.Message);
            }
        }

        public async Task<Address> Get(int key)
        {
            var adress = await _context.Addresses
                .Include(address => address.Customer)
              .SingleOrDefaultAsync(address => address.Id == key);
            if (adress == null)
            {
                throw new KeyNotFoundException("Address not found.");
            }
            return adress;
        }

        public async Task<IEnumerable<Address>> GetList()
        {
            return await _context.Addresses
                .OrderBy(address => address.City)
                .ToListAsync();
        }

        public async Task<Address> Update(Address address)
        {
            try
            {
                await Get(address.Id);
                _context.ChangeTracker.Clear();
                _context.Addresses.Update(address);
                await _context.SaveChangesAsync();
                return address;
            }
            catch (DbUpdateException error)
            {
                throw new DbUpdateException(error.Message);
            }
        }
    }
}
