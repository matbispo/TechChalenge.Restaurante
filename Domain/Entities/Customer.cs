using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Customer
    {
        public string Name{ get; set; }
        public CPF Cpf { get; set; }
    }
}
