namespace ShoppingWebApp.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShoppingWebAppDbContext _shoppingWebAppDbContext;
public CategoryRepository(ShoppingWebAppDbContext shoppingWebAppDbContext)
        {
            _shoppingWebAppDbContext = shoppingWebAppDbContext;
        }

        public IEnumerable<Category> AllCategories => _shoppingWebAppDbContext.Categories.OrderBy(u => u.CategoryName);
    }
}
