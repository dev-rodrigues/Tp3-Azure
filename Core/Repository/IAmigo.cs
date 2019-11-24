﻿using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository {
    public interface IAmigo {

        Task<bool> Salvar(Amigo amigo);

        Amigo Buscar(int id);
    }
}