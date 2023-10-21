using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalSys.Models
{
    [Table("Tbl_Admin")]
    public class AdminModel
    {
        [Key]
        public int AdminId { get; set; }



        [Required(ErrorMessage = "User Name is required")]
        [Display(Name = "User Name")]
        [MinLength(3, ErrorMessage = "Minimum 3 Character required"), MaxLength(10, ErrorMessage = "Maximum 10 Character Allowed")]

        public string AdName { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "Minimum 5 Character required"), MaxLength(10, ErrorMessage = "Maximum 10 Character Allowed")]
        public string Password { get; set; }

    }
}
