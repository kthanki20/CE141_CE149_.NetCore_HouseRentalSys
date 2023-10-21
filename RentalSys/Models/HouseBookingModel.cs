using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RentalSys.Models
{
    [Table("Tbl_HouseBooking")]
    public class HouseBookingModel
    {
        [Key]
        public int Bid { get; set; }

        [Required(ErrorMessage = "Name Required")]
        [Display(Name = "Customer Name")]
        public string bCusName { get; set; }


        [Required(ErrorMessage = "Address Required")]
        [Display(Name = "Customer Address")]
        public string bCusAddress { get; set; }

        [Required]
        [Display(Name = "Customer Email")]
        public string bCusEmail { get; set; }


        [Display(Name = "Phone Number")]
        [Required]
        public string bCusPhoneNum { get; set; }

        [Required, Display(Name = "CNIC")]
        public string bCusCnic { get; set; }

        //one to many relation between TicketReserve model and flightbooking model
        public int HouseId { get; set; }
        //public virtual HouseDetailModel houseDetailsModel    { get; set; }
    }
}
