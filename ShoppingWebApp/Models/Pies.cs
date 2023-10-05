using System.ComponentModel;

namespace ShoppingWebApp.Models
{
    public class Pies
    {
        public int PiesId { get; set; }
        public string Name { get; set;} = string.Empty;  //string.Empty to show that Name cannot be null.
        public string? LongDescription { get; set; }
        public string? ShortDescription { get; set; }
        public string? AllergyInformation { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageThumbnailUrl { get; set; }
        public decimal Price { get; set; }
        public bool IsPieOfTheWeek { get; set; }
        public bool InStock { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;  //Category cannot be null.
    }
}
