namespace Looh.Domain.Entities;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = null!;
    public string Telephone { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public DateTime DateBirth { get; set; }
    public ICollection<Establishment> Establishments { get; set; } = new List<Establishment>();
}
