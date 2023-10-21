using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RentalSys.Models
{
    [Table("Tbl_HouseDetail")]
    public class HouseDetailModel
    {
        [Key]
        public int HouseID { get; set; }

        [Required(ErrorMessage = "Please enter your House Name"), Display(Name = "House Name:")]
        public string HouseName { get; set; }

        [Required(ErrorMessage = "Please enter House Type"), Display(Name = "House Type:")]
        public string HouseType { get; set; }

        [Required(ErrorMessage = "Please enter House Rent Amount"), Display(Name = "House Rent Amount")]
        public string HouseRentAmount { get; set; }

        [Required(ErrorMessage = "Please enter your Address"), Display(Name = "House Address")]
        public string HouseAddress { get; set; }



        public virtual ICollection<HouseBookingModel> Tbl_HouseBookings { get; set; }
    }
}
