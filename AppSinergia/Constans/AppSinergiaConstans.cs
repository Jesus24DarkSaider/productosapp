using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSinergia.Constans
{
    public static class AppSinergiaConstans
    {
        // URIS DE SERVICIOS A ORQUESTAR

        // CATEGORIAS
        public const string GET_CONSULTAR_CATEGORIAS = "es/categoria/v1";
        
        // PROVEEDOR
        public const string GET_CONSULTAR_PROVEEDOR = "es/proveedor/v1";
        
        //  GESTION DE PRODUCTOS
        public const string GET_CONSULTAR_PRODUCTO_POR_CATEGORIAID = "es/producto/categoria/v1/{categoriaId}";
        public const string GET_CONSULTAR_PRODUCTOS = "es/producto/v1";
        public const string GET_CONSULTAR_PRODUCTOS_POR_PROVEEDOR = "es/producto/proveedor/v1/{proveedorId}";
        public const string POST_REGISTRAR_PRODUCTO = "es/producto/v1";
        public const string PUT_MODIFICAR_PRODUCTO = "es/producto/v1";
    }
}
