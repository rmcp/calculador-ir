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
    public class AliquotaServiceTest
    {
        private readonly Mock<IAliquotaService> _aliquotaMockService;
        private readonly Aliquota _aliquotaNotEmpty;
        private readonly Aliquota _aliquotaEmpty;
        private readonly decimal _salarioMinimo = 1045;
        private readonly decimal _rendaLiquida = 10000;

        public AliquotaServiceTest()
        {
            _aliquotaMockService = new Mock<IAliquotaService>();

            _aliquotaNotEmpty = new Aliquota
            {
                Id = new Guid(),
                Porcentagem = 10,
                SalarioMax = 10,
                SalarioMin = 0
            };

            _aliquotaEmpty = null;
        }

        [TestMethod]
        public void Get_Deve_Passar(){
            Task<Aliquota> aliquotaResult = Task.FromResult(_aliquotaNotEmpty);

            _aliquotaMockService.Setup(d => d.Get(It.IsAny<decimal>(), It.IsAny<decimal>())).Returns(aliquotaResult);

            var resultMockService = _aliquotaMockService.Object.Get(_salarioMinimo, _rendaLiquida).Result;           


            Assert.IsTrue(resultMockService != null);
        }

        [TestMethod]
        public void Get_Nao_Deve_Passar()
        {
        
            Task<Aliquota> aliquotaResult = Task.FromResult(_aliquotaEmpty);

            _aliquotaMockService.Setup(d => d.Get(It.IsAny<decimal>(), It.IsAny<decimal>())).Returns(aliquotaResult);

            var resultMockService = _aliquotaMockService.Object.Get(_salarioMinimo, _rendaLiquida).Result;

            Assert.IsTrue(resultMockService == null);
        }
        

        [TestMethod]
        public void GetAll_Deve_Passar()
        {
            IEnumerable<Aliquota> listAliquotasMock = new List<Aliquota>
            {
                _aliquotaNotEmpty,
                new Aliquota
                {
                    Id = new Guid(),
                    Porcentagem = 11,
                    SalarioMax = 11,
                    SalarioMin = 7
                }
            };
            
            Task<IEnumerable<Aliquota>> calculoResult = Task.FromResult(listAliquotasMock);

            _aliquotaMockService.Setup(d => d.GetAll()).Returns(calculoResult);

            var resultService = _aliquotaMockService.Object.GetAll().Result;

            Assert.IsTrue(resultService.Any());
        }

        [TestMethod]
        public void GetAll_Nao_Deve_Passar()
        {
            IEnumerable<Aliquota> listAliquotasMock = new List<Aliquota>();

            Task<IEnumerable<Aliquota>> calculoResult = Task.FromResult(listAliquotasMock);

            _aliquotaMockService.Setup(d => d.GetAll()).Returns(calculoResult);

            var resultService = _aliquotaMockService.Object.GetAll().Result;


            Assert.IsTrue(!resultService.Any());
        }
        
    }
}
