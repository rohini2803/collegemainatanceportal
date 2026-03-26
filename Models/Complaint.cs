using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace collegemainatanceportal.Models;

public class Complaint
{
    [Key]
    public int Id { get; set; }  // Primary Key

    [Required]
    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Category { get; set; }

    public string? Priority { get; set; }

    public string? Status { get; set; } = "Pending";

    public DateTime? CreatedDate { get; set; }

    public string? UserId { get; set; }

    public string? Location { get; set; }
    public string ImagePath { get; set; }

    [NotMapped]
    public IFormFile ImageFile { get; set; }
    public string StaffStatus { get; set; } = "Pending";
    
}
