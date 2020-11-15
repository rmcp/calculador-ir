using System;

namespace calculator_api.DTO
{
    public class CalculoDTO
    {
        public Guid ContribuinteId { get; set; }
        public string Nome { get; set; }       
        public decimal ImpostoCalculado { get; set; }
    }
}
