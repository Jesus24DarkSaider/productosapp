using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using AppSinergia.Models;
using System.Reflection;
using AppSinergia.KeyReader;
using AppSinergia.Constans;
namespace AppSinergia.Services
{
    public class RestClient
    {
        
        private HttpClient restClient;
        string urlBase;

      public  RestClient() {
            // CONFIGURAMOS EL CLIENTE REST ASIGNANDOLE TIEMPO
            /// DE RESPUESTAS MAXIMO DE UN MINUTO
            restClient = new HttpClient();
            TimeSpan timeOut = new TimeSpan(0,0,60);
            restClient.Timeout = timeOut;

            // DEFINIMOS LA URL BASE DEL HOST DONDE SE REALIZARA LA PETICION
            var appSettingsJson = AppSettingsJson.GetAppSettings();
            urlBase = appSettingsJson["hostService"].ToString();
        }

        
        public async Task<CategoriaResponse> consultarCategorias() {
            CategoriaResponse categoriaResponse = new CategoriaResponse();
            string uriConsumo = urlBase + AppSinergiaConstans.GET_CONSULTAR_CATEGORIAS;
            try
            {
                var uri = new Uri(uriConsumo);
                
                // CONSUMO DE LA CAPACIDAD DE CONSULTAR CATEGORIAS DEL SERVICIO PRODUCTO ES
                var consumoCategorias = restClient.GetAsync(uri);

                if (consumoCategorias.Result.IsSuccessStatusCode) {
                    var response = await consumoCategorias.Result.Content.ReadAsStringAsync();
                    categoriaResponse = JsonConvert.DeserializeObject<CategoriaResponse>(response);
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
            return categoriaResponse;
        }

        public async Task<ProveedorResponse> consultarProveedores() {
            ProveedorResponse proveedorResponse = new ProveedorResponse();
            string uriConsumo = urlBase + AppSinergiaConstans.GET_CONSULTAR_PROVEEDOR;
            try
            {
                var uri = new Uri(uriConsumo);
                
                // CONSUMO DE LA CAPACIDAD CONSULTAR PROVEEDORES DEL SERVICIO PRODUCTO ES
                var consumoProveedor = restClient.GetAsync(uri);
                
                if (consumoProveedor.Result.IsSuccessStatusCode)
                {
                    var response = await consumoProveedor.Result.Content.ReadAsStringAsync();
                    proveedorResponse = JsonConvert.DeserializeObject<ProveedorResponse>(response);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return proveedorResponse;
        }

        public async Task<ProductoResponse> consultarProductos()
        {
            ProductoResponse productosResponse = new ProductoResponse();
            string uriConsumo = urlBase + AppSinergiaConstans.GET_CONSULTAR_PRODUCTOS;
            try
            {
                var uri = new Uri(uriConsumo);

                // CONSUMO DE LA CAPACIDAD CONSULTAR PROVEEDORES DEL SERVICIO PRODUCTO ES
                var consumoProductos = restClient.GetAsync(uri);

                if (consumoProductos.Result.IsSuccessStatusCode)
                {
                    var response = await consumoProductos.Result.Content.ReadAsStringAsync();
                    productosResponse = JsonConvert.DeserializeObject<ProductoResponse>(response);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return productosResponse;
        }



        public async Task<ProductoResponse> consultarProductoPorProveedorId(string proveedorId) {
            ProductoResponse productoResponse = new ProductoResponse();
            string urlConsumo = urlBase + AppSinergiaConstans.GET_CONSULTAR_PRODUCTOS_POR_PROVEEDOR;
            try
            {
                Uri uri = new Uri(urlConsumo.Replace("{proveedorId}",proveedorId));

                // CONSULTAR PRODUCTO POR PROVEEDOR ID
                var consumoProducto = restClient.GetAsync(uri);

                if (consumoProducto.Result.IsSuccessStatusCode) {

                    var response = await consumoProducto.Result.Content.ReadAsStringAsync();

                    productoResponse = JsonConvert.DeserializeObject<ProductoResponse>(response);
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
            return productoResponse;
        }


        public async Task<ProductoResponse> consultarProductoPorCategoriaId(string categoriaId) {
            ProductoResponse productoResponse = new ProductoResponse();
            string urlConsumo = urlBase + AppSinergiaConstans.GET_CONSULTAR_PRODUCTO_POR_CATEGORIAID;
            try
            {
                Uri uri = new Uri(urlConsumo.Replace("{categoriaId}", categoriaId));       
                var consumoProducto = restClient.GetAsync(uri);

                if (consumoProducto.Result.IsSuccessStatusCode) {

                    var response = await consumoProducto.Result.Content.ReadAsStringAsync();

                    productoResponse = JsonConvert.DeserializeObject<ProductoResponse>(response);

                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
            return productoResponse;
        }


        public async Task<RespuestaType> crearProducto(ProductoModels producto) {
            RespuestaType respuestaType = new RespuestaType();
            string urlConsumo = urlBase + AppSinergiaConstans.POST_REGISTRAR_PRODUCTO;
            try
            {
                Uri url = new Uri(urlConsumo);
                var request = JsonConvert.SerializeObject(producto);
                var content = new StringContent(request, Encoding.UTF8, "application/json");

                var consumoProducto = restClient.PostAsync(url, content);

                if (consumoProducto.Result.IsSuccessStatusCode)
                {
                    var response = await consumoProducto.Result.Content.ReadAsStringAsync();
                    respuestaType = JsonConvert.DeserializeObject<RespuestaType>(response);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return respuestaType;
        }


        public async Task<RespuestaType> modificarProducto(ProductoModels producto) {
            RespuestaType respuestaType = new RespuestaType();
            string urlConsumo = urlBase + AppSinergiaConstans.PUT_MODIFICAR_PRODUCTO;
            try
            {
                Uri uri = new Uri(urlConsumo);
                var request = JsonConvert.SerializeObject(producto);
                var content = new StringContent(request, Encoding.UTF8, "application/json");

                var consumoProducto = restClient.PutAsync(uri,content);

                if (consumoProducto.Result.IsSuccessStatusCode) {

                    var response = await consumoProducto.Result.Content.ReadAsStringAsync();

                    respuestaType = JsonConvert.DeserializeObject<RespuestaType>(response);

                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);
            }

            return respuestaType;
        }


    }
}
