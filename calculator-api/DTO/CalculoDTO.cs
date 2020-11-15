using calculator_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace calculator_api.DTO
{
    public class CalculoDTO
    {
        public Guid ContribuinteId { get; set; }
        public string Nome { get; set; }       
        public decimal ImpostoCalculado { get; set; }
    }
}
