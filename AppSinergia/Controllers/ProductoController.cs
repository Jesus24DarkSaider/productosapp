using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppSinergia.Services;
using AppSinergia.Models;
namespace AppSinergia.Controllers
{
    public class ProductoController : Controller
    {
        RestClient servicio = new RestClient();


        public async Task<IActionResult> Index()
        {
            // Consultamos las categorias
            CategoriaResponse categoria = new CategoriaResponse();
            categoria = await servicio.consultarCategorias();


            //Consultamos el listado de productos
          //  ProductoResponse listadoProductos = new ProductoResponse();
          //  listadoProductos = await servicio.consultarProductos();

            // Consultamos el listado de proveedores
            ProveedorResponse listadoProveedores = new ProveedorResponse();
            listadoProveedores = await servicio.consultarProveedores();

            ModuloProductos model = new ModuloProductos();
            model.categoriaResponse = categoria;
           // model.listadoProductos = listadoProductos;
            model.listadoProveedores = listadoProveedores;
            return View(model);
        }

        [HttpGet]
        public JsonResult consultarProductos() {
             List<ProductoDTO> producto = new List<ProductoDTO>();
             ProductoResponse response = new ProductoResponse();
             response =  servicio.consultarProductos().Result;
             producto = response.listadoProducto;
             return Json(new { data = producto });
        }

    }
}
