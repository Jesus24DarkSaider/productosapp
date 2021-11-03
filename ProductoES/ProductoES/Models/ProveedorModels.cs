using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductoES.Models
{
    public class ProveedorModels
    {
        public int id_proveedor { get; set; }
        public string nombre_proveedor { get; set; }
        public string estado { get; set; }
    }

    public class ProveedorResponse {
        public List<ProveedorModels> listaProveedores { get; set; }
        public RespuestaType respuesta { get; set; }
    }
}