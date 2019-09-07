using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SGQ.Domain.Entities;
using SGQ.Domain.Interfaces;
using System;

namespace SGQTest
{
    [TestClass]
    public class DomainTest
    {
        private Mock<IRepository<Atividade>> mockAtividade;

        [TestInitialize]
        public void TestInitializeMock()
        {
            mockAtividade = new Mock<IRepository<Atividade>>(MockBehavior.Strict);
            mockAtividade.Setup(s => s.ObterPorId(1))
              .Returns(() => new  Atividade());
             
        }

        [TestMethod]
        [TestCategory("Repository")]
        public void TestRepositoryAtividade()
        {
            var repository = mockAtividade.Object;
            var result = repository.ObterPorId(1);
            Assert.IsNotNull(result);
        }
    }

}
