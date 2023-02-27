using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TuffyHealthNew.Models
{
    
    public class PatientLogs
    {
        [Key]
        public int TreatmentID { get; set; }
        public DateTime Patient_log_date { get; set; }
        public string? Dosage { get; set; }
        public string? Result { get; set; }
        
        public ApplicationUser ApplicationUser { get; set; }
        public Treatments Treatments { get; set; }
    }
}
