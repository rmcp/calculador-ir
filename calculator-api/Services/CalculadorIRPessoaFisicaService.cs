using System;
using System.Collections.Generic;
using calculator_api.DTO;
using calculator_api.Models;
using calculator_api.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace calculator_api.Services
{
    public class CalculadorIRPessoaFisicaService : ICalculadorIRService, IDisposable
    {

        private readonly ICalculoIRService _calculoIRService;
        private readonly IAliquotaService _aliquotaService;
        private readonly IContribuinteService _contribuinteService;


        public CalculadorIRPessoaFisicaService(ICalculoIRService calculoIRService, IAliquotaService aliquotaService, IContribuinteService contribuinteService)
        {
            _calculoIRService = calculoIRService;
            _aliquotaService = aliquotaService;
            _contribuinteService = contribuinteService;
        }

        public async Task<IEnumerable<CalculoDTO>> Calcular(IList<DadosCalculoDTO> dados ){
            
            var novosCalculos = new List<CalculoIR>();

            foreach (DadosCalculoDTO dado in dados)
            {
                                
                decimal rendaLiquida = dado.RendaBruta - dado.Dependentes * (dado.SalarioMinimo * 0.05m);
                var aliquota = _aliquotaService.Get(dado.SalarioMinimo, rendaLiquida).Result;
                var impostoDevido = rendaLiquida * aliquota.Porcentagem / 100;

                var contribuinte = new Contribuinte
                {
                    Nome = dado.Nome,
                    Cpf = dado.Cpf,
                    Renda = dado.RendaBruta,
                    Dependentes = dado.Dependentes
                };


                contribuinte = await _contribuinteService.Save(contribuinte);

                var novoCalculoIR = new CalculoIR
                {
                    Contribuinte = contribuinte,
                    Data = DateTime.Now,
                    Dependentes = dado.Dependentes,
                    RendaBruta = dado.RendaBruta,
                    RendaLiquida = rendaLiquida,
                    ImpostoDevido = impostoDevido
                };

                novosCalculos.Add(novoCalculoIR);

            }

            await _calculoIRService.SaveAll(novosCalculos);

            //return _calculoIRRepository.GetAll().Result.OrderBy(c => c.Contribuinte.Nome).ThenBy(c => c.ImpostoDevido).ToList();

            var novosCalculosDTO = new List<CalculoDTO>();

            foreach (var calculo in novosCalculos)
            {
                novosCalculosDTO.Add(new CalculoDTO
                {
                    ContribuinteId = calculo.Contribuinte.Id,
                    Nome = calculo.Contribuinte.Nome,
                    ImpostoCalculado = calculo.ImpostoDevido
                });
            }

            return novosCalculosDTO;
            
        }

        protected virtual void Dispose(bool disposing)
        {            
            if (disposing)
            {
                _calculoIRService.Dispose();
                _aliquotaService.Dispose();
                _contribuinteService.Dispose();
            }                       
        }       
       

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }        
    }
}