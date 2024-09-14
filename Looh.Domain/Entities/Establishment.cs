namespace Looh.Domain.Entities
{
    public class Establishment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = null!;
        public DateTime FundationDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Telephone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Cnpj { get; set; } = null!;
        public string Cpf { get; set; } = null!;
        public string WorkingHours { get; set; } = null!;
        public string IntervalHours { get; set; } = null!;
        public List<string> WorkingDays { get; set; } = new List<string>();
    }
}
