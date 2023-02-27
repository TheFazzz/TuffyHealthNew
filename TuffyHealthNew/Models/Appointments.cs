using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TuffyHealthNew.Models
{ 
    public class Appointments
    {
        //public string Id { get; set; }
        [Key]
        public int AppointmentID { get; set; }
        public DateTime Appointment_date { get; set; }
        public string? Time { get; set; }

        public ApplicationUser ApplicationUser { get; set; }


    }
}
