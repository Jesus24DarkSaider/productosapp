using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppSinergia.Models
{
    public class ProductoModels
    {

        public int id_producto { get; set; }
        public string nombre_producto { get; set; }
        public string descripcion { get; set; }
        public int cantidad { get; set; }
        public decimal precio_unitario { get; set; }
        public int categoria_id { get; set; }
        public int marca_id { get; set; }
        public int medida_id { get; set; }
        public int proveedor_id { get; set; }

    }

    public class ProductoDTO
    {

        public int id_producto { get; set; }
        public string nombre_producto { get; set; }
        public string descripcion { get; set; }
        public int cantidad { get; set; }
        public decimal precio_unitario { get; set; }
        public string nombre_categoria { get; set; }
        public string nombre_marca { get; set; }
        public string nombre_medida { get; set; }
        public string nombre_proveedor { get; set; }

    }

    public class ProductoResponse
    {
        public List<ProductoDTO> listadoProducto { get; set; }
        public RespuestaType respuesta { get; set; }
    }


    public class ModuloProductos
    {
        public CategoriaResponse categoriaResponse { get; set; }
        public ProductoResponse listadoProductos { get; set; }
        public ProveedorResponse listadoProveedores { get; set; }
    }
}