using Microsoft.EntityFrameworkCore;

namespace ShoppingWebApp.Models
{
    public class PiesRepository : IPiesRepository
    {
        private readonly ShoppingWebAppDbContext _shoppingWebAppDbContext;

        public PiesRepository(ShoppingWebAppDbContext shoppingWebAppDbContext)
        {
            _shoppingWebAppDbContext = shoppingWebAppDbContext;
        }

        public IEnumerable<Pies> AllPies
        {
            get
            {
                return _shoppingWebAppDbContext.Pies.Include(u => u.Category);
            }
        }

        public IEnumerable<Pies> PiesOfTheWeek
        {
            get
            {
                return _shoppingWebAppDbContext.Pies.Include(u => u.Category).Where(u => u.IsPieOfTheWeek);
            }
        }

        public Pies? GetPieById(int pieId)
        {
            return _shoppingWebAppDbContext.Pies.FirstOrDefault(u => u.PiesId == pieId);
        }
    }
}
