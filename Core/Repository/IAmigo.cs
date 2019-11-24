using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository {
    public interface IAmigo {

        Amigo SalvarEF(Amigo amigo);

        Amigo Salvar(Amigo amigo);

        void Apagar(int Id);

        Amigo Buscar(int id);
    }
}
