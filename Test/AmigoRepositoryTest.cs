using API.Service;
using Core.Model;
using Core.Repository;
using Data.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test {
    [TestClass]
    public class AmigoRepositoryTest {

        private IAmigo repositorio = ServiceLocator.GetInstanceOf<AmigoRepository>();

        [TestMethod]
        public void TestSalvarAmigo_GeraId() {
            
            var amigo = new Amigo();
            
            var amigoEncontrado = SalvarAmigoTest(amigo);
            
            Assert.AreEqual(amigo.Id, amigoEncontrado.Id);
        }

        [TestMethod]
        public void Deve_RetornarNome_Quando_SalvarAmigo() {
            var amigo = new Amigo();
            amigo.Nome = "carlos";

            var amigoEncontrado = SalvarAmigoTest(amigo);

            Assert.AreEqual("carlos", amigoEncontrado.Nome);
        }

        private Amigo SalvarAmigoTest(Amigo amigo) {
            repositorio.Salvar(amigo);
            return repositorio.Buscar(amigo.Id);
        }
    }
}
