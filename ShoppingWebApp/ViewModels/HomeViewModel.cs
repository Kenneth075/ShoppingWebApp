using ShoppingWebApp.Models;

namespace ShoppingWebApp.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Pies> PiesOfTheWeek { get; }

        public HomeViewModel(IEnumerable<Pies> piesOfTheWeek)
        {
            PiesOfTheWeek = piesOfTheWeek;
        }

        
    }
}
