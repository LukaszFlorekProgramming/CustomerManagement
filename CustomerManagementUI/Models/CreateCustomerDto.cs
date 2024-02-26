using System.ComponentModel.DataAnnotations;

namespace CustomerManagementUI.Models
{
    public class CreateCustomerDto
    {
        [Required(ErrorMessage = "Nazwa jest wymagana.")]
        [MaxLength(150, ErrorMessage = "Nazwa nie może przekroczyć 150 znaków.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Adres jest wymagany.")]
        [MaxLength(250, ErrorMessage = "Adres nie może przekroczyć 250 znaków.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Wymagany NIP.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "NIP musi składać się z 10 cyfr.")]
        public string NIP { get; set; }
    }
}
