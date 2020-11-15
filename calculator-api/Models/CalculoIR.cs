using System;
using System.Collections.Generic;

namespace calculator_api.Models
{
    public class CalculoIR
    {

        public Guid Id { get; set; }
        public Contribuinte Contribuinte { get; set; }
        //public ICollection<Dependente> Dependentes { get; set; }

        public int Dependentes { get; set; }

        //public FormulaRL FormulaRL { get; set; }

        public decimal RendaBruta { get; set; }
        public decimal SalarioMinimo { get; set; }
        public decimal RendaLiquida { get; set; }

        public decimal ImpostoDevido { get; set; }

        public DateTime Data { get; set; }

    }
}