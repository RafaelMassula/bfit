using bfitapi.Data.IServices;
using bfitapi.Exceptions;
using bfitapi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bfitapi.Data.Services
{
    public class ProductRepository : Services<Product>, IProductRepository
    {
        private readonly BfitContext _context;
        public ProductRepository(BfitContext context)
        {
            _context = context;
        }
        public async Task<Product> Create(Product product)
        {
            try
            {
                await CheckExistenceOfRecord(product);
                _context.Add(product);
                await _context.SaveChangesAsync();
                return await Get(product.Id);
            }
            catch (DbUpdateException error)
            {
                throw new DbUpdateException(error.Message);
            }
        }

        public async Task<Product> Delete(int key)
        {
            var product = await Get(key);

            try
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return product;
            }
            catch (DbUpdateException error)
            {
                throw new DbUpdateException(error.Message);
            }
        }

        public async Task<Product> Get(int key)
        {
            var product = await _context.Products
                .SingleOrDefaultAsync(product => product.Id == key);
            if (product == null)
            {
                throw new KeyNotFoundException("Product not found.");
            }
            return product;
        }

        public async Task<IEnumerable<Product>> GetList()
        {
            return await _context.Products
                .OrderBy(product => product.Description)
                .ToListAsync();
        }

        public async Task<Product> Update(Product product)
        {
            try
            {
                await Get(product.Id);
                _context.ChangeTracker.Clear();
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                return product;
            }
            catch (DbUpdateException error)
            {
                throw new DbUpdateException(error.Message);
            }
        }
    

        public override async Task CheckExistenceOfRecord(Product product)
        {
            var products = await GetList();

            foreach (var p in products)
            {
                if (product.Equals(p))
                    throw new DbUpdateException("Product has already been registered.");
            }
            _context.ChangeTracker.Clear();
        }
    }
}
