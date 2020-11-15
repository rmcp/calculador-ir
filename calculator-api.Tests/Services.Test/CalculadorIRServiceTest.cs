using Microsoft.VisualStudio.TestTools.UnitTesting;
using calculator_api.Services;
using calculator_api.DTO;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace calculator_api.Tests
{
    [TestClass]
    public class CalculadorIRServiceTest
    {        
        private readonly Mock<ICalculadorIRService> _calculadorMockService;

        public CalculadorIRServiceTest()
        {            
            _calculadorMockService = new Mock<ICalculadorIRService>();            
        }
        

        [TestMethod]
        public void Calcular_Deve_Passar()
        {
            var listDadosMock = new List<DadosCalculoDTO>
            {
                new DadosCalculoDTO { Cpf = "111111", Dependentes = 1, Nome = "Teste", RendaBruta = 1000, SalarioMinimo = 1045 }                
            };
            

            IEnumerable<CalculoDTO> resultList = new List<CalculoDTO> {
                new CalculoDTO { ContribuinteId = new System.Guid(), Nome = "Teste", ImpostoCalculado = 1000 }
            };

            Task<IEnumerable<CalculoDTO>> calculoResult = Task.FromResult(resultList);

            _calculadorMockService.Setup(d => d.Calcular(It.IsAny<IList<DadosCalculoDTO>>())).Returns(calculoResult);

            var resultService =  _calculadorMockService.Object.Calcular(listDadosMock).Result;

            var resultadoTeste = resultService.ToList();


            Assert.IsTrue(resultadoTeste.Count > 0);

        }

        [TestMethod]
        public void Calcular_Nao_Deve_Passar()
        {            

            var listDadosMock = new List<DadosCalculoDTO>
            {
                new DadosCalculoDTO { Cpf = "111111", Dependentes = 1, Nome = "Teste", RendaBruta = -1000, SalarioMinimo = 1045 }
            };
           
            IEnumerable<CalculoDTO> resultList = new List<CalculoDTO> {
                new CalculoDTO { ContribuinteId = new System.Guid(), Nome = "Teste", ImpostoCalculado = 1000 }
            };

            Task<IEnumerable<CalculoDTO>> calculoResult = Task.FromResult(resultList);

            _calculadorMockService.Setup(d => d.Calcular(It.IsAny<IList<DadosCalculoDTO>>())).Throws(new ArgumentException("Aliquota não encontrada.Verifique os parâmetros passados"));
            
            try
            {
                var resultService = _calculadorMockService.Object.Calcular(listDadosMock).Result;                
            } catch (ArgumentException ex) {                
                Assert.IsTrue(ex.Message.Equals("Aliquota não encontrada.Verifique os parâmetros passados"));
            }
            
        }
        
    }
}
