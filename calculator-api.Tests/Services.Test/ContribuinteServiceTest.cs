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
    public class ContribuinteServiceTest
    {
        private readonly Mock<IContribuinteService> _contribuinteMockService;
        private readonly Contribuinte _contribuinteNotEmpty;
        private readonly Contribuinte _contribuinteEmpty;

        public ContribuinteServiceTest()
        {
            _contribuinteMockService = new Mock<IContribuinteService>();

            _contribuinteNotEmpty = new Contribuinte
            {
                Id = new Guid(),
                CalculoIRs = null,
                Cpf = "1",
                Dependentes = 1,
                Nome = "Teste",
                Renda = 1000
            };

            _contribuinteEmpty = null;
        }

        [TestMethod]
        public void Get_Deve_Passar(){
            Task<Contribuinte> contribuinteResult = Task.FromResult(_contribuinteNotEmpty);

            _contribuinteMockService.Setup(d => d.Get(It.IsAny<Guid>())).Returns(contribuinteResult);

            var resultMockService = _contribuinteMockService.Object.Get(new Guid()).Result;           


            Assert.IsTrue(resultMockService != null);
        }

        [TestMethod]
        public void Get_Nao_Deve_Passar()
        {
        
            Task<Contribuinte> contribuinteResult = Task.FromResult(_contribuinteEmpty);

            _contribuinteMockService.Setup(d => d.Get(It.IsAny<Guid>())).Returns(contribuinteResult);

            var resultMockService = _contribuinteMockService.Object.Get(new Guid()).Result;


            Assert.IsTrue(resultMockService == null);
        }


        [TestMethod]
        public void GetByCpf_Deve_Passar()
        {
            Task<Contribuinte> contribuinteResult = Task.FromResult(_contribuinteNotEmpty);

            _contribuinteMockService.Setup(d => d.GetByCpf(It.IsAny<string>())).Returns(contribuinteResult);

            var resultMockService = _contribuinteMockService.Object.GetByCpf("1").Result;


            Assert.IsTrue(resultMockService != null);
        }

        [TestMethod]
        public void GetByCpf_Nao_Deve_Passar()
        {
            Task<Contribuinte> contribuinteResult = Task.FromResult(_contribuinteEmpty);

            _contribuinteMockService.Setup(d => d.GetByCpf(It.IsAny<string>())).Returns(contribuinteResult);

            var resultMockService = _contribuinteMockService.Object.GetByCpf("1").Result;


            Assert.IsTrue(resultMockService == null);
        }

        [TestMethod]
        public void GetAll_Deve_Passar()
        {
            IEnumerable<Contribuinte> listContribuintesMock = new List<Contribuinte>
            {
                _contribuinteNotEmpty,
                new Contribuinte
                {
                    Id = new Guid(),
                    CalculoIRs = null,
                    Cpf = "2",
                    Dependentes = 1,
                    Nome = "Teste2",
                    Renda = 1000
                }
            };
            
            Task<IEnumerable<Contribuinte>> calculoResult = Task.FromResult(listContribuintesMock);

            _contribuinteMockService.Setup(d => d.GetAll()).Returns(calculoResult);

            var resultService = _contribuinteMockService.Object.GetAll().Result;


            Assert.IsTrue(resultService.Any());
        }

        [TestMethod]
        public void GetAll_Nao_Deve_Passar()
        {
            IEnumerable<Contribuinte> listContribuintesMock = new List<Contribuinte>();

            Task<IEnumerable<Contribuinte>> calculoResult = Task.FromResult(listContribuintesMock);

            _contribuinteMockService.Setup(d => d.GetAll()).Returns(calculoResult);

            var resultService = _contribuinteMockService.Object.GetAll().Result;


            Assert.IsTrue(!resultService.Any());
        }

        [TestMethod]
        public void Save_Deve_Passar()
        {   

            Task<Contribuinte> contribuinteResult = Task.FromResult(_contribuinteNotEmpty);

            _contribuinteMockService.Setup(d => d.Save(It.IsAny<Contribuinte>())).Returns(contribuinteResult);

            var resultMockService = _contribuinteMockService.Object.Save(_contribuinteNotEmpty).Result;

            Assert.IsTrue(resultMockService != null);
        }


        [TestMethod]
        public void Save_Nao_Deve_Passar()
        {            

            Task<Contribuinte> contribuinteResult = Task.FromResult(_contribuinteEmpty);

            _contribuinteMockService.Setup(d => d.Save(It.IsAny<Contribuinte>())).Returns(contribuinteResult);

            var resultMockService = _contribuinteMockService.Object.Save(_contribuinteEmpty).Result;


            Assert.IsTrue(resultMockService == null);
        }

    }
}
