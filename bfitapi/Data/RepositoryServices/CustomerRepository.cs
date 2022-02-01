using bfitapi.Data.IServices;
using bfitapi.Data.Services;
using bfitapi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace bfitapi.Data.RepositoryServices
{
    public class CustomerRepository : Services<Customer>, ICustomerRepository
    {
        private readonly BfitContext _context;
        public CustomerRepository(BfitContext context)
        {
            _context = context;
        }
        public async Task<Customer> Create(Customer customer)
        {
            await CheckExistenceOfRecord(customer);
            CustomerServices.CheckedBirthDate(customer.BirthDate);
            CustomerServices.CheckedCpf(customer.Cpf);
            customer.Cpf = Regex.Replace(customer.Cpf, @"[A-Za-z-\W]+", "");
      
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return await Get(customer.Id);
        }

        public async Task<Customer> Delete(int key)
        {
            var customer = await Get(key);

            try
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
                return customer;
            }
            catch (DbUpdateException error)
            {
                throw new DbUpdateException(error.Message);
            }
        }

        public async Task<Customer> Get(int key)
        {
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };
            var customer = await _context.Customers
                .Include(customer => customer.Adresses)
                .SingleOrDefaultAsync(customer => customer.Id == key);
           string Jsoncustomer = JsonSerializer.Serialize(customer, options);
            if (customer == null)
                throw new KeyNotFoundException("Customer not found");

            return customer;
        }

        public async Task<IEnumerable<Customer>> GetList()
        {
            return await _context.Customers
                .OrderBy(customer => customer.Name)
                .ToListAsync();
        }

        public async Task<Customer> Update(Customer customer)
        {
            try
            {
                await Get(customer.Id);
                CustomerServices.CheckedBirthDate(customer.BirthDate);
                CustomerServices.CheckedCpf(customer.Cpf);
                customer.Cpf = Regex.Replace(customer.Cpf, @"[A-Za-z-\W]+", "");
                _context.ChangeTracker.Clear();
                _context.Customers.Update(customer);
                await _context.SaveChangesAsync();
                return customer;
            }
            catch (DbUpdateException error)
            {
                throw new DbUpdateException(error.Message);
            }
        }

        public override async Task CheckExistenceOfRecord(Customer customer)
        {
            var customers = await GetList();

            foreach (var c in customers)
            {
                if (customer.Equals(c))
                    throw new DbUpdateException("Customer has already been registered.");
            }
            _context.ChangeTracker.Clear();
        }
    }
}
