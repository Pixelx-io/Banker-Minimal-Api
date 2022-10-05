namespace Banker.Entities.Dtos;

public class ResponseDto
{
    public bool IsSuccessRequest { get; set; }

    public object Results { get; set; }

    public IEnumerable<string> Errors { get; set; }

    public DateTime __timestamp { get; set; } = DateTime.Now;
}