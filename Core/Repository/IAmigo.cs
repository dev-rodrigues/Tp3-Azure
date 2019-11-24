using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository {
    public interface IAmigo {

        Amigo SalvarEF(Amigo amigo);

        List<Amigo> Listar();

        Amigo Salvar(Amigo amigo);

        Amigo Editar(Amigo amigo);

        void Apagar(int Id);

        Amigo Buscar(int id);
    }
}
