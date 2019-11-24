using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model {
    public class Amigo {

        public int Id {
            get; set;
        }
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

        public DateTime? DataDeNascimento {
            get; set;
        }
    }
}
