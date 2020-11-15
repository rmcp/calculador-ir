using calculator_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace calculator_api.DTO
{
    public class DadosCalculoDTO
    {       
        public string Nome { get; set; }

        public string Cpf { get; set; }

        public int Dependentes { get; set; }
        public decimal RendaBruta { get; set; }

        public decimal SalarioMinimo { get; set; }
    }
}
