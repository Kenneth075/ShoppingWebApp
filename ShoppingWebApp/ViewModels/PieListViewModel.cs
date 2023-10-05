using ShoppingWebApp.Models;

namespace ShoppingWebApp.ViewModels
{
    public class PieListViewModel
    {
        public IEnumerable<Pies> Pies { get; set; }
        public string? CurrentCategory { get; set; }

        public PieListViewModel(IEnumerable<Pies> pies, string currentCategory)
        {
            Pies = pies;
            CurrentCategory = currentCategory;
        }

    }
}
