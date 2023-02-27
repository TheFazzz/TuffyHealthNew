using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TuffyHealthNew.Models;
public class Treatments
{
    [Key]   
    public int TreatmentID { get; set; }

    public string? TreatmentType { get; set; }

    public string? TreatmentName { get; set; }
}
