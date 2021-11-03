using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Web.Configuration;
using System.Configuration.Assemblies; 
using System.Data.SqlClient;
using ProductoES.Models;
using ProductoES.Repository;


namespace ProductoES.Controllers
{

    public class ProductosController : ApiController
    {

        [System.Web.Http.Route("es/producto/categoria/v1/{categoriaId}")]
        [System.Web.Http.HttpGet]
        public ProductoResponse consultarProductosPorCategoriaId(int categoriaId)
        {
            ProductoResponse productoResponse = new ProductoResponse();
            RespuestaType respuestaType = new RespuestaType();
            try
            {
                using (dbproductos db = new dbproductos())
                {
                    var productos = db.Database.SqlQuery<ProductoDTO>
                        ("consultarProductosPorCategoria @categoriaId ",
                        new SqlParameter("@categoriaId", categoriaId)).ToList();

                    productoResponse.listadoProducto = productos;
                    respuestaType.Codigo = 200;
                    respuestaType.Descripcion = "Consulta Exitosa";

                }
            }
            catch (Exception ex)
            {
                respuestaType.Codigo = 500;
                respuestaType.Descripcion = ex.ToString();
            }
            productoResponse.respuesta = respuestaType;
            return productoResponse;
        }

        [System.Web.Http.Route("es/producto/v1")]
        [System.Web.Http.HttpGet]
        public ProductoResponse consultarProductos()
        {
            ProductoResponse productoResponse = new ProductoResponse();
            RespuestaType respuestaType = new RespuestaType();
            try
            {
                using (dbproductos db = new dbproductos())
                {
                    var productos = db.Database.SqlQuery<ProductoDTO>
                        ("SPConsultarProductos").ToList();

                    productoResponse.listadoProducto = productos;

                    respuestaType.Codigo = 200;
                    respuestaType.Descripcion = "Consulta Exitosa";
                }
            }
            catch (Exception ex)
            {
                respuestaType.Codigo = 500;
                respuestaType.Descripcion = ex.ToString();
            }

            productoResponse.respuesta = respuestaType;
            return productoResponse;
        }


        [System.Web.Http.Route("es/producto/proveedor/v1/{proveedorId}")]
        [System.Web.Http.HttpGet]
        public ProductoResponse consultarProductosPorProveedorId(int proveedorId)
        {
            ProductoResponse productoResponse = new ProductoResponse();
            RespuestaType respuestaType = new RespuestaType();
            try
            {
                using (dbproductos db = new dbproductos())
                {
                    var productos = db.Database.SqlQuery<ProductoDTO>
                        ("consultarProductosPorProveedor @proveedorId",
                        new SqlParameter("@proveedorId", proveedorId)).ToList();

                    productoResponse.listadoProducto = productos;

                    respuestaType.Codigo = 200;
                    respuestaType.Descripcion = "Consulta Exitosa";
                }
            }
            catch (Exception ex)
            {
                respuestaType.Codigo = 500;
                respuestaType.Descripcion = ex.ToString();
                productoResponse.respuesta =respuestaType;
            }
            return productoResponse;
        }

        [System.Web.Http.Route("es/producto/v1")]
        [System.Web.Http.HttpPost]
        public RespuestaType crearProducto(ProductoModels producto)
        {
            RespuestaType respuesta = new RespuestaType();
            try
            {
                using (dbproductos db = new dbproductos())
                {
                    tb_producto tbProducto = new tb_producto();
                    tbProducto.nombre_producto = producto.nombre_producto;
                    tbProducto.descripcion = producto.descripcion;
                    tbProducto.cantidad = producto.cantidad;
                    tbProducto.precio_unitario = producto.precio_unitario;
                    tbProducto.marca_id = producto.marca_id;
                    tbProducto.medida_id = producto.medida_id;
                    tbProducto.proveedor_id = producto.proveedor_id;
                    db.tb_producto.Add(tbProducto);
                    db.SaveChanges();

                    respuesta.Codigo = 201;
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

        [System.Web.Http.Route("es/producto/v1")]
        [System.Web.Http.HttpPut]
        public RespuestaType actualizarProducto(ProductoModels producto)
        {
            RespuestaType respuesta = new RespuestaType();
            try
            {
                using (dbproductos db = new dbproductos())
                {

                    tb_producto tbProducto = new tb_producto();
                    tbProducto.id_producto = producto.id_producto;
                    tbProducto.nombre_producto = producto.nombre_producto;
                    tbProducto.descripcion = producto.descripcion;
                    tbProducto.cantidad = producto.cantidad;
                    tbProducto.precio_unitario = producto.precio_unitario;
                    tbProducto.marca_id = producto.marca_id;
                    tbProducto.medida_id = producto.medida_id;
                    tbProducto.proveedor_id = producto.proveedor_id;
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
