using System.ComponentModel.DataAnnotations;

namespace Banker.Entities.Models;

public class AccountModel
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string? Name { get; set; }

    [Required]
    [StringLength(255)]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    [Range(0, double.MaxValue)]
    public decimal Balance { get; set; }

    [Required]
    public DateTime CreatedDate { get; set; }
}