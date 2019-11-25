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
            var amigo = CriaAmigoFake();
            var amigoEncontrado = SalvarAmigoTest(amigo);
            Assert.IsNotNull(amigoEncontrado.Id);
        }

        [TestMethod]
        public void Deve_RetornarNome_Quando_SalvarAmigo() {
            var amigo = CriaAmigoFake();
            var amigoEncontrado = SalvarAmigoTest(amigo);
            Assert.AreEqual("carlos", amigoEncontrado.Nome);
        }

        [TestMethod]
        public void Deve_RetornarAmigo_Quando_EditarAmigo() {
            var amigo = CriaAmigoFake();
            var amigosalvo = SalvarAmigoTest(amigo);
            var amigoEditado = EditarAmigoTest(amigosalvo);
            Assert.IsNotNull(amigoEditado);
        }

        [TestMethod]
        public void Deve_VerificarNomeAmigo_Quando_BuscarAmigo() {
            var amigo = CriaAmigoFake();
            var amigoSalvo = SalvarAmigoTest(amigo);
            var amigoBuscado = BuscarAmigo(amigoSalvo.Id);

            Assert.IsNotNull(amigoBuscado.Nome);
        }

        private Amigo CriaAmigoFake() {
            var amigo = new Amigo();
            amigo.Nome = "carlos";
            amigo.SobreNome = "rodrigues";
            amigo.Email = "carlos@gmail.com";
            amigo.Telefone = "12345678";
            amigo.DataDeNascimento = DateTime.Now;
            return amigo;
        }

        private Amigo SalvarAmigoTest(Amigo amigo) {
            var amigo_salvo = repositorio.Salvar(amigo);
            var amigo_buscado = BuscarAmigo(amigo_salvo.Id);
            return amigo_buscado;
        }

        private Amigo EditarAmigoTest(Amigo amigoEditado) {
            var amigo = BuscarAmigo(amigoEditado.Id);
            amigo.Nome = amigoEditado.Nome;
            amigo.SobreNome = amigoEditado.SobreNome;
            amigo.Telefone = amigoEditado.Telefone;
            amigo.Email = amigoEditado.Email;
            amigo.DataDeNascimento = amigoEditado.DataDeNascimento;
            return repositorio.Editar(amigo);
        }

        private Amigo BuscarAmigo(int idAmigo) {
            return repositorio.Buscar(idAmigo);
        }
    }
}
