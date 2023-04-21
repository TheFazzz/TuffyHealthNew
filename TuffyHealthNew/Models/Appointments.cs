using System.ComponentModel.DataAnnotations;

namespace TuffyHealthNew.Models
{
    public class Appointments
    {
        //public string Id { get; set; }
        [Key]
        public int AppointmentID { get; set; }
        [DataType(DataType.Date)]
        public DateTime Appointment_date { get; set; }
        public string? Time { get; set; }

        public ApplicationUser ApplicationUser { get; set; }


    }
}
