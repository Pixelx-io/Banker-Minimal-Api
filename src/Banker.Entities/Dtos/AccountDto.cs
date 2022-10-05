using System.ComponentModel.DataAnnotations;

namespace Banker.Entities.Dtos;

public class AccountDto
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public decimal Balance { get; set; }
}