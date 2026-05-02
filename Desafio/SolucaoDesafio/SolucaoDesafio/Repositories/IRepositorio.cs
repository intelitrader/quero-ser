using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Entidades.Interfaces
{
    interface IRepositorio<T>
    {
        List<T> Lista(string caminhoArquivo);
    }
}
