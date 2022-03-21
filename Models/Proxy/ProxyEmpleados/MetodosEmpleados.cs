using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRentBook.Models.Proxy.ProxyEmpleados
{
    public class MetodosEmpleados : ControlesEmpleados
    {
        private ControlesEmpleados controlesEmpleados;

        public override void agregarEmpleado(Persona persona)
        {
            if (controlesEmpleados == null)
            {
                controlesEmpleados = new ControlesEmpleados();
            }
            controlesEmpleados.agregarEmpleado(persona);
        }
        public override void eliminarEmpleado(Persona persona)
        {
            if (controlesEmpleados == null)
            {
                controlesEmpleados = new ControlesEmpleados();
            }
            controlesEmpleados.eliminarEmpleado(persona);
        }
        public override void editarEmpleado(Persona persona)
        {
            if (controlesEmpleados == null)
            {
                controlesEmpleados = new ControlesEmpleados();
            }
            controlesEmpleados.editarEmpleado(persona);
        }
        public override List<Persona> leerEmpleados()
        {
            if (controlesEmpleados == null)
            {
                controlesEmpleados = new ControlesEmpleados();
            }
            return controlesEmpleados.leerEmpleados();
        }

    }
}
