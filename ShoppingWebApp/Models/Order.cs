using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace ShoppingWebApp.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }

        [Required(ErrorMessage ="Please enter your first name")]
        [Display(Name ="First name")]
        [StringLength(20)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your last name")]
        [Display(Name = "Last name")]
        [StringLength(20)]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage ="Enter your addressline")]
        [StringLength (50)]
        public string AddressLine1 { get; set; } = string.Empty;

        [StringLength(50)]
        public string? AddressLine2 { get; set; }
        

        [Required(ErrorMessage ="Enter your Zip Code")]
        [StringLength(7,MinimumLength =4)]
        public string ZipCode { get; set; } =string.Empty;

        [Required]
        [StringLength(15)]
        public string City { get; set; } = string.Empty;

        [Required]
        [StringLength(15)]
        public string State { get; set; } = string.Empty;

        [Required]
        [StringLength(15)]
        public string Country { get; set; } = string.Empty;

        [Required(ErrorMessage ="Please enter your phone number")]
        [StringLength(15)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name ="Phone number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage ="Please enter your email address")]
        [StringLength(30)]
        [DataType(DataType.EmailAddress)]
        [Display(Name ="email address")]
        public string Email { get; set; } = string.Empty;

        [BindNever]
        public decimal OrderTotal { get; set; }

        [BindNever]
        public DateTime OrderPlaced { get; set; }
    }
}
