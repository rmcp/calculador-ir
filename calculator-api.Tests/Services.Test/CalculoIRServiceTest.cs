using calculator_api.DTO;
using calculator_api.Models;
using calculator_api.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace calculator_api.Tests
{
    [TestClass]
    public class CalculoIRServiceTesta
    {
        private readonly Mock<ICalculoIRService> _calculoIRMockService;
        private readonly CalculoIR _calculoNotEmpty;
        private readonly CalculoIR _calculoEmpty;
        private readonly CalculoDTO _calculoDTONotEmpty;

        public CalculoIRServiceTesta()
        {
            _calculoIRMockService = new Mock<ICalculoIRService>();

            _calculoNotEmpty = new CalculoIR
            {
                Id = new Guid(),
                Contribuinte = new Contribuinte(new Guid()),
                Data = DateTime.Now,
                Dependentes = 1,
                ImpostoDevido = 2000,
                RendaBruta = 10000,
                RendaLiquida = 9500,
                SalarioMinimo = 1045
            };

            _calculoEmpty = null;

            _calculoDTONotEmpty = new CalculoDTO { ContribuinteId = new Guid(), Nome = "Teste", ImpostoCalculado = 1000 };
        }

        [TestMethod]
        public void Get_Deve_Passar(){
            Task<CalculoIR> calculoIrResult = Task.FromResult(_calculoNotEmpty);

            _calculoIRMockService.Setup(d => d.Get(It.IsAny<Guid>())).Returns(calculoIrResult);

            var resultMockService = _calculoIRMockService.Object.Get(new Guid()).Result;           


            Assert.IsTrue(resultMockService != null);
        }

        [TestMethod]
        public void Get_Nao_Deve_Passar()
        {

            Task<CalculoIR> calculoIrResult = Task.FromResult(_calculoEmpty);

            _calculoIRMockService.Setup(d => d.Get(It.IsAny<Guid>())).Returns(calculoIrResult);

            var resultMockService = _calculoIRMockService.Object.Get(new Guid()).Result;


            Assert.IsTrue(resultMockService == null);
        }
       

        [TestMethod]
        public void GetAll_Deve_Passar()
        {
            IEnumerable<CalculoDTO> listCalculosDTOMock = new List<CalculoDTO>
            {
                _calculoDTONotEmpty,
                new CalculoDTO { ContribuinteId = new Guid(), Nome = "Teste2", ImpostoCalculado = 1500 }
            };
            
            Task<IEnumerable<CalculoDTO>> calculoResult = Task.FromResult(listCalculosDTOMock);

            _calculoIRMockService.Setup(d => d.GetAll()).Returns(calculoResult);

            var resultService = _calculoIRMockService.Object.GetAll().Result;

            Assert.IsTrue(resultService.Any());
        }

        [TestMethod]
        public void GetAll_Nao_Deve_Passar()
        {
            IEnumerable<CalculoDTO> listCalculosDTOMock = new List<CalculoDTO>();

            Task<IEnumerable<CalculoDTO>> calculoResult = Task.FromResult(listCalculosDTOMock);

            _calculoIRMockService.Setup(d => d.GetAll()).Returns(calculoResult);

            var resultService = _calculoIRMockService.Object.GetAll().Result;

            Assert.IsTrue(!resultService.Any());
        }

        [TestMethod]
        public void Save_Deve_Passar()
        {

            Task<CalculoIR> calculoIrResult = Task.FromResult(_calculoNotEmpty);

            _calculoIRMockService.Setup(d => d.Save(It.IsAny<CalculoIR>())).Returns(calculoIrResult);

            var resultService = _calculoIRMockService.Object.Save(_calculoNotEmpty).Result;

            Assert.IsTrue(resultService != null);
        }


        [TestMethod]
        public void Save_Nao_Deve_Passar()
        {

            Task<CalculoIR> calculoIrResult = Task.FromResult(_calculoEmpty);

            _calculoIRMockService.Setup(d => d.Save(It.IsAny<CalculoIR>())).Returns(calculoIrResult);

            var resultService = _calculoIRMockService.Object.Save(_calculoNotEmpty).Result;

            Assert.IsTrue(resultService == null);
        }

        [TestMethod]
        public void SaveAll_Deve_Passar()
        {

            IEnumerable<CalculoIR> listCalculosMock = new List<CalculoIR>
            {
                _calculoNotEmpty,
                new CalculoIR
                {
                    Id = new Guid(),
                    Contribuinte = new Contribuinte(new Guid()),
                    Data = DateTime.Now,
                    Dependentes = 2,
                    ImpostoDevido = 2500,
                    RendaBruta = 15000,
                    RendaLiquida = 13500,
                    SalarioMinimo = 1045
                }
            };

            Task<IEnumerable<CalculoIR>> calculoResult = Task.FromResult(listCalculosMock);

            _calculoIRMockService.Setup(d => d.SaveAll(It.IsAny<IList<CalculoIR>>())).Returns(calculoResult);

            var resultService = _calculoIRMockService.Object.SaveAll(listCalculosMock).Result;

            Assert.IsTrue(resultService.Any());
        }


        [TestMethod]
        public void SaveAll_Nao_Deve_Passar()
        {

            IEnumerable<CalculoIR> listCalculosMock = new List<CalculoIR>();

            Task<IEnumerable<CalculoIR>> calculoResult = Task.FromResult(listCalculosMock);

            _calculoIRMockService.Setup(d => d.SaveAll(It.IsAny<IList<CalculoIR>>())).Returns(calculoResult);

            var resultService = _calculoIRMockService.Object.SaveAll(listCalculosMock).Result;

            Assert.IsTrue(!resultService.Any());
        }

    }
}
