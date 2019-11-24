using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models {
    public class AmigoBindModel {
        public string Nome {
            get; set;
        }

        public string SobreNome {
            get; set;
        }

        public string Email {
            get; set;
        }

        public string Telefone {
            get; set;
        }

        public string Aniversario {
            get; set;
        }

        public Amigo CriarAmigo(AmigoBindModel inputModel) {
            var amigo = new Amigo() {
                Nome = inputModel.Nome,
                SobreNome = inputModel.SobreNome,
                Email = inputModel.Email,
                Telefone = inputModel.Telefone,
                DataDeNascimento = ConverteData(inputModel.Aniversario)
            };
            return amigo;
        }

        public Amigo CriarAmigo() {
            return new Amigo();
        }

        private DateTime ConverteData(string aniversarioString) {
            var anoMesDia = aniversarioString.Split('/');

            var ano = Convert.ToInt32(anoMesDia[2]);
            var mes = Convert.ToInt32(anoMesDia[1]);
            var dia = Convert.ToInt32(anoMesDia[0]);
            DateTime data = new DateTime(ano, mes, dia);
            return data;
        }
    }
}