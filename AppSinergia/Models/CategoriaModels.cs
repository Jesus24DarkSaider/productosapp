using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppSinergia.Models
{
    public class CategoriaModels
    {
        public int id_categoria  { get; set; }
        public string nombre_categoria { get; set; }
        public string estado { get; set; }
    }

    public class CategoriaResponse
    {
        public List<CategoriaModels> listadoCategorias { get; set; }
        public RespuestaType respuesta { get; set; }
    }
}