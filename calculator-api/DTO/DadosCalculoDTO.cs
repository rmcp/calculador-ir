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
