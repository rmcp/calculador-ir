using System;
using System.Collections.Generic;

namespace calculator_api.Models
{
    public class Aliquota
    {

        public Guid Id { get; set; }
        public int SalarioMin { get; set; } = 0;
        public int SalarioMax { get; set; } = int.MaxValue;
        public decimal Porcentagem { get; set; }                

    }
}