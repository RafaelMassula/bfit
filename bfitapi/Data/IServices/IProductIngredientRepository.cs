using bfitapi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bfitapi.Data.IServices
{
    public interface IProductIngredientRepository
    {
        public Task<Product_Ingredient> Create(Product_Ingredient product_Ingredient);
        public Task<Product_Ingredient> Delete(int keyProduct, int keyIngredient);
        public Task<Product_Ingredient> Get(int keyProduct, int keyIngredient);
    }
}
