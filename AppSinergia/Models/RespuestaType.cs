using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppSinergia.Models
{
    public class RespuestaType
    {

        private int codigo;
        private string descripcion;

        public int Codigo
        {
            get
            {
                return codigo;
            }

            set
            {
                codigo = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }
    }
}