using System;
using System.Collections.Generic; 

namespace calculator_api.Models {
    public class Contribuinte : Pessoa {
        
        public Contribuinte()
        {
            
        }

        public Contribuinte (Guid Id) {
            this.Id = Id;            
        }

        public Contribuinte (string nome, string cpf, decimal renda) {
            this.Nome = nome;
            this.Cpf = cpf;
            this.Renda = renda;
        }        
        
        public decimal Renda { get; set; }

        //public ICollection<Dependente> Dependentes { get; set; }        

        public int Dependentes { get; set; }

        public ICollection<CalculoIR> CalculoIRs { get; set; }   

    }
}