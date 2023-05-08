using System.ComponentModel.DataAnnotations;

namespace TuffyHealthNew.Models
{
    public class Appointments
    {
        
        [Key]
        public int AppointmentID { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Appointment Date")]
        public DateTime Appointment_date { get; set; }
        public string? Time { get; set; }
        [Display(Name = "Doctor Seen")]
        public string? Doctor { get; set; }

        public ApplicationUser ApplicationUser { get; set; }


    }
}
