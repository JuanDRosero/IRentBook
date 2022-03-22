using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRentBook.Models.Patron_Cadena
{
    public abstract class Persona
    {
        protected Persona suc;
        public void SetSucc(Persona suc)
        {
            this.suc = suc;
        }
        public abstract IRentBook.Models.Persona EncontrarUsEm(int codigo, string password);
    }
}
