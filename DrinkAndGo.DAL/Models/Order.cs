using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkAndGo.DAL.Models
{
    public class Order
    {
        public Order()
        {
            OrderLines = new List<OrderDetail>();
        }
        //[BindNever]
        public int OrderId { get; set; }

        public List<OrderDetail> OrderLines { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "First name")]
        //[StringLength(50)
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        [Display(Name = "Last name")]
        //[StringLength(50)]    
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your address")]
        //[StringLength(100)]
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "Please enter your zip code")]
        [Display(Name = "Zip code")]
        //[StringLength(10, MinimumLenkth = 4)]
        public string ZipCode { get; set; }

        //[StringLength(10)]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter your country")]
        //[StringLength(5kkkkkkkkkkkk
        public string Country { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        //[StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        //[StringLength(50)]
        [DataType(DataType.EmailAddress, ErrorMessage = "The email address is not entered in a correct format")]
      
        public string Email { get; set; }

        //[BindNever]
        //[ScaffoldColumn(false)]
        public decimal OrderTotal { get; set; }

        //[BindNever]
        //[ScaffoldColumn(false)]
        public DateTime OrderPlaced { get; set; }=DateTime.Now;
    }
}


