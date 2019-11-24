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

        public int[] Aniversario {
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

        private DateTime ConverteData(int[] anoMesDia) {
            var ano = Convert.ToInt32(anoMesDia[0]);
            var mes = Convert.ToInt32(anoMesDia[1]);
            var dia = Convert.ToInt32(anoMesDia[2]);
            DateTime data = new DateTime(ano,mes,dia);
            return data;
        }
    }
}