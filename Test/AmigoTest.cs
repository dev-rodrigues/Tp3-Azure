using System;
using API.Models;
using Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test {
    [TestClass]
    public class AmigoTest {

        [TestMethod]
        public void Deve_RetornarAmigo_Quando_Criado() {
            var amigo = CriarAmigo();
            Assert.IsNotNull(amigo);
        }

        [TestMethod]
        public void Deve_VerificarSeExisteNome_Quando_Criado() {
            var amigo = CriarAmigo();
            amigo.Nome = "carlos";
            Assert.AreEqual("carlos", amigo.Nome);
        }

        [TestMethod]
        public void Deve_VerificarSeExisteSobreNome_Quando_Criado() {
            var amigo = CriarAmigo();
            amigo.SobreNome = "rodrigues";
            Assert.AreEqual("rodrigues", amigo.SobreNome);
        }

        [TestMethod]
        public void Deve_VerificarSeExisteEmail_Quando_Criado() {
            var amigo = CriarAmigo();
            amigo.Email = "carlos@gmail.com";
            Assert.AreEqual("carlos@gmail.com", amigo.Email);
        }

        [TestMethod]
        public void Deve_VerificarSeExisteTelefone_Quando_Criado() {
            var amigo = CriarAmigo();
            amigo.Telefone = "12345678";
            Assert.AreEqual("12345678", amigo.Telefone);
        }

        [TestMethod]
        public void Deve_VerificarSeExisteAniversario_Quando_Criado() {
            var amigo = CriarAmigo();
            amigo.DataDeNascimento = new DateTime(1994, 10, 5);
            Assert.AreEqual(new DateTime(1994, 10, 5), amigo.DataDeNascimento);
        }

        private Amigo CriarAmigo() {
            return new AmigoBindModel().CriarAmigo();
        }
    }
}
