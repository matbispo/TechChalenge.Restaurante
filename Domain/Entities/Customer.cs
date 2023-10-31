using Domain.ValueObjects;

namespace Domain.Entities
{
    public record Customer
    {
        public long Id { get; set; }
        public string Name{ get; set; }
        public string Email{ get; set; }
        public CPF Cpf { get; set; }
    }
}
