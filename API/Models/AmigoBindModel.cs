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

        public Amigo CriarAmigo(AmigoBindModel inputModel) {
            var amigo = new Amigo() {
                Nome = inputModel.Nome
            };
            return amigo;
        }
    }
}