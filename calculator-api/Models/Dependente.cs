using System;
using System.Collections.ObjectModel;

namespace calculator_api.Models
{
    public class Dependente : Pessoa
    {   

        public Dependente()
        {
            
        }

        public Dependente (Guid Id) {
            this.Id = Id;            
        }

        public Dependente(string Nome, string Cpf) {
            this.Nome = Nome;
            this.Cpf = Cpf;
        }        

        public Guid ContribuinteId { get; set; }

        public Collection<CalculoIR> CalculosIRs { get; set; }

    }
}