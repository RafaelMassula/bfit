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
    public class ProductIngredientRepository : Services<Product_Ingredient>, IProductIngredientRepository
    {
        private readonly BfitContext _context;
        public ProductIngredientRepository(BfitContext context)
        {
            _context = context;
        }
        public async Task<Product_Ingredient> Create(Product_Ingredient product_Ingredient)
        {
            try
            {
                await CheckExistenceOfRecord(product_Ingredient);
                _context.Product_Ingredients.Add(product_Ingredient);
                await _context.SaveChangesAsync();
                return product_Ingredient;
            }
            catch (DbUpdateException error)
            {
                throw new DbUpdateException(error.Message);
            }
        }

        public async Task<Product_Ingredient> Delete(int keyProduct, int keyIngredient)
        {
            var productIngredient = await Get(keyProduct, keyIngredient);
            try
            {
                _context.Product_Ingredients.Remove(productIngredient);
                await _context.SaveChangesAsync();
                return productIngredient;
            }
            catch (DbUpdateException error)
            {
                throw new DbUpdateException(error.Message);
            }
        }

        public async Task<Product_Ingredient> Get(int keyProduct, int keyIngredient)
        {
            var productIngredient = await _context.Product_Ingredients.SingleOrDefaultAsync(productIngredient => productIngredient.IngredientId == keyIngredient &
              productIngredient.ProductId == keyProduct);
            if (productIngredient == null)
                throw new KeyNotFoundException("Relationship not found.");
            return productIngredient;


        }

        public async override Task CheckExistenceOfRecord(Product_Ingredient product_Ingredient)
        {
            var productIngredient = await Get(product_Ingredient.ProductId, product_Ingredient.IngredientId);
            if (productIngredient != null)
                throw new DbUpdateException("Relationship type has already been registered.");
            _context.ChangeTracker.Clear();
        }
    }
}
