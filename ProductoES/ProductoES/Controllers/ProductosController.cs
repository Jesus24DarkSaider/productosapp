using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Web.Configuration;
using System.Configuration.Assemblies;
using ProductoES.Models;
using ProductoES.Repository;

namespace ProductoES.Controllers
{

    public class ProductosController : ApiController
    {
        public RespuestaType Crear(ProductoModels producto)
        {
            RespuestaType respuesta = new RespuestaType();

            try
            {
                using (dbproductos db = new dbproductos())
                {
                    tb_producto tbProducto = new tb_producto();
                    tbProducto.nombre_producto = producto.nombreProducto;
                    tbProducto.descripcion = producto.descripcion;
                    tbProducto.cantidad = producto.cantidad;
                    tbProducto.precio_unitario = producto.precioUnitario;
                    tbProducto.marca_id = producto.marcaId;
                    tbProducto.medida_id = producto.medidaId;
                    tbProducto.proveedor_id = producto.proveedorId;
                    db.tb_producto.Add(tbProducto);
                    db.SaveChanges();
                    respuesta.Codigo = 200;
                    respuesta.Descripcion = "OK";
                }
            }
            catch (Exception ex)
            {
                respuesta.Codigo = 500;
                respuesta.Descripcion = ex.ToString();
            }
            return respuesta;
        }

    }
}
