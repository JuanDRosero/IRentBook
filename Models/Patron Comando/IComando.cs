using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRentBook.Models.Patron_Comando
{
    public interface IComando
    {
        public bool ejecutar();
    }
}
