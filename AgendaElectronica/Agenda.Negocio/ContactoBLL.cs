using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Entidad;
using Agenda.Datos;

namespace Agenda.Negocio
{
    public class ContactoBLL
    {
        private ContactoDAL contactoDAL = new ContactoDAL();

        public bool InsertarContacto(Contacto contacto)
        {
            // Aquí podrías poner validaciones antes de guardar
            return contactoDAL.InsertarContacto(contacto);
        }

        public bool ModificarContacto(Contacto contacto)
        {
            return contactoDAL.ModificarContacto(contacto);
        }

        public bool EliminarContacto(int id)
        {
            return contactoDAL.EliminarContacto(id);
        }

        public List<Contacto> BuscarContacto(string texto)
        {
            return contactoDAL.BuscarContacto(texto);
        }
    }
}
