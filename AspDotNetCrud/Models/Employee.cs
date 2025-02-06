using System.ComponentModel.DataAnnotations;

namespace AspDotNetCrud.Models
{
    public class Employee
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "First Name is Required.")]
        [MaxLength(50, ErrorMessage = "First Name should contain maximum fifty charactors")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "First Name is Required.")]
        [MaxLength(50, ErrorMessage = "First Name should contain maximum fifty charactors")]
        public string LasttName { get; set; }
        public string MobileNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string AddressLine1 { get; set; }
        public string AdressLine2 { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }



    }
}
