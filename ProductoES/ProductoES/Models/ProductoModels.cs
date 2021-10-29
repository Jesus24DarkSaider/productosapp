using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductoES.Models
{
    public class ProductoModels
    {

        public int idProducto { get; set; }
        public string nombreProducto { get; set; }
        public string descripcion { get; set; }
        public int cantidad { get; set; }
        public decimal precioUnitario { get; set; }
        public int categoriaId { get; set; }
        public int marcaId { get; set; }
        public int medidaId { get; set; }
        public int proveedorId { get; set; }

    }
}