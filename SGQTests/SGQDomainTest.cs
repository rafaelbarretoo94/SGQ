using Microsoft.VisualStudio.TestTools.UnitTesting;
using SGQ.Domain.Entities;
using SGQ.Domain.Interfaces;
using SGQ.Infra.Data.Context;
using SGQ.Infra.Data.Repository;

namespace SGQTests
{
    [TestClass]
    public class SgqDomainTest
    {
        public readonly IRepository<Usuario> _repository;

        public SgqDomainTest(IRepository<Usuario> repository)
        {
            _repository = repository;
        }
        [TestMethod]
        public void GetRepository()
        {

            var teste = _repository.SelecionarTodos();
            Assert.IsNotNull(teste);
            //using (var rep = Repository<Usuario>)
            //{
            //    var teste = rep.SelecionarTodos();
            //}

            

            //IRepository<Usuario> teste = IRepository<Usuario>;
            //teste.SelecionarTodos();
            //var result = repositorioUsuarios.SelecionarTodos();
            //Assert.IsNotNull(result);            
        }
    }
}
