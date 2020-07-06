using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using CloudForAllTest.API.Models;
using CloudForAllTest.Domain;
using CloudForAllTest.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CloudForAllTest.API.Controllers
{
    [ApiController]
    [Route("api/producto")]
    public class ProductoController : ControllerBase
    {
        private readonly ILogger<ProductoController> logger;
        private readonly IMapper mapper;
        private readonly IProductoService productoService;

        public ProductoController(ILogger<ProductoController> _logger,
                                  IProductoService _productoService,
                                  IMapper _mapper)
        {
            logger = _logger;
            mapper = _mapper;
            productoService = _productoService;
        }

        [HttpGet]
        public async Task<ResponseModel> GetProductos()
        {
            ResponseModel response;

            try
            {
                IEnumerable<Producto> productos = await productoService.GetProductos();
                IEnumerable<ProductoApiModel> productosResponse = mapper.Map<List<ProductoApiModel>>(productos);

                response = new ResponseModel
                {
                    HttpResponse = (int)HttpStatusCode.OK,
                    Response = productosResponse
                };

            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

                response = new ResponseModel
                {
                    HttpResponse = (int)HttpStatusCode.InternalServerError,
                    ErrorResponse = "Ha ocurrido un error, consulte con el administrador"
                };
            }

            return response;
        }

        [HttpGet("{id}")]
        public async Task<ResponseModel> GetProducto(string id)
        {
            ResponseModel response;

            try
            {
                Producto producto = await productoService.GetProducto(id);
                ProductoApiModel productoResponse = mapper.Map<ProductoApiModel>(producto);

                response = new ResponseModel
                {
                    HttpResponse = (int)HttpStatusCode.OK,
                    Response = productoResponse
                };

            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

                response = new ResponseModel
                {
                    HttpResponse = (int)HttpStatusCode.InternalServerError,
                    ErrorResponse = "Ha ocurrido un error, consulte con el administrador"
                };
            }

            return response;
        }

        [HttpPost]
        public async Task<ResponseModel> CreateProducto(ProductoApiModelCreate producto)
        {
            ResponseModel response;

            try
            {
                Producto productoCreate = mapper.Map<Producto>(producto);
                await productoService.CreateProducto(productoCreate);

                response = new ResponseModel
                {
                    HttpResponse = (int)HttpStatusCode.Created,
                    Response = "Se ha creado el producto exitosamente"
                };

            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

                response = new ResponseModel
                {
                    HttpResponse = (int)HttpStatusCode.InternalServerError,
                    ErrorResponse = "Ha ocurrido un error, consulte con el administrador"
                };
            }

            return response;
        }

        [HttpPut]
        public async Task<ResponseModel> UpdateProducto(ProductoApiModel producto)
        {
            ResponseModel response;

            try
            {
                Producto productoUpdate = mapper.Map<Producto>(producto);
                await productoService.UpdateProducto(productoUpdate);

                response = new ResponseModel
                {
                    HttpResponse = (int)HttpStatusCode.OK,
                    Response = "Se ha actualizado el producto exitosamente"
                };
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

                response = new ResponseModel
                {
                    HttpResponse = (int)HttpStatusCode.InternalServerError,
                    ErrorResponse = "Ha ocurrido un error, consulte con el administrador"
                };
            }

            return response;
        }

        [HttpDelete("{id}")]
        public async Task<ResponseModel> DeleteProducto(string id)
        {
            ResponseModel response;

            try
            {
                await productoService.DeleteProducto(id);

                response = new ResponseModel
                {
                    HttpResponse = (int)HttpStatusCode.OK,
                    Response = "Se ha eliminado el producto exitosamente"
                };

            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

                response = new ResponseModel
                {
                    HttpResponse = (int)HttpStatusCode.InternalServerError,
                    ErrorResponse = "Ha ocurrido un error, consulte con el administrador"
                };
            }

            return response;
        }
    }
}
