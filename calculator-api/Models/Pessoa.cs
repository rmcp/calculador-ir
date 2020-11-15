using System;
using System.Runtime.Serialization;

namespace calculator_api.Models
{
    public abstract class Pessoa
    {
        public Pessoa()
        {

        }
        
        public Pessoa(Guid Id)
        {
            this.Id = Id;
        }

        public Pessoa(string Nome, string Cpf)
        {
            this.Nome = Nome;
            this.Cpf = Cpf;
        }

        public Guid Id { get; set; }        
        public string Nome { get; set; }       
        
        public string Cpf { get; set; }
    }
}