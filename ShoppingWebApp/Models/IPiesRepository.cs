namespace ShoppingWebApp.Models
{
    public interface IPiesRepository
    {
         IEnumerable<Pies> AllPies { get; }
         IEnumerable<Pies> PiesOfTheWeek { get; }
         Pies GetPieById(int pieId);
    }
}
