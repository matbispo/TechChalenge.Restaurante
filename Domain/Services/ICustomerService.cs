using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aplication
{
    public interface ICustomerService
    {

        void CreateCustomer(Customer customer);
        Customer GetCustomerByCpf(string customerCpf);
    }
}
