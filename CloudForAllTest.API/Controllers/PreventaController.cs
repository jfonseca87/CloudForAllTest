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
    [Route("api/preventa")]
    public class PreventaController : ControllerBase
    {
        private readonly ILogger<PreventaController> logger;
        private readonly IMapper mapper;
        private readonly IPreventaService preventaService;

        public PreventaController(ILogger<PreventaController> _logger,
                                  IPreventaService _preventaService,
                                  IMapper _mapper)
        {
            logger = _logger;
            mapper = _mapper;
            preventaService = _preventaService;
        }

        [HttpGet]
        public async Task<ResponseModel> GetPreventas()
        {
            ResponseModel response;

            try
            {
                IEnumerable<Preventa> preventas = await preventaService.GetPreventas();
                IEnumerable<PreventaApiModel> preventasResponse = mapper.Map<List<PreventaApiModel>>(preventas);

                response = new ResponseModel
                {
                    HttpResponse = (int)HttpStatusCode.OK,
                    Response = preventasResponse
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
        public async Task<ResponseModel> GetPreventa(string id)
        {
            ResponseModel response;

            try
            {
                Preventa preventa = await preventaService.GetPreventa(id);
                PreventaApiModel preventaResponse = mapper.Map<PreventaApiModel>(preventa);

                response = new ResponseModel
                {
                    HttpResponse = (int)HttpStatusCode.OK,
                    Response = preventa
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
        public async Task<ResponseModel> CreatePreventa(PreventaApiModelCreate preventa)
        {
            ResponseModel response;

            try
            {
                Preventa preventaCreate = mapper.Map<Preventa>(preventa);
                await preventaService.CreatePreventa(preventaCreate);

                response = new ResponseModel
                {
                    HttpResponse = (int)HttpStatusCode.Created,
                    Response = "Se ha creado la preventa exitosamente"
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
        public async Task<ResponseModel> UpdatePreventa(PreventaApiModel preventa)
        {
            ResponseModel response;

            try
            {
                Preventa preventaUpdate = mapper.Map<Preventa>(preventa);
                await preventaService.UpdatePreventa(preventaUpdate);

                response = new ResponseModel
                {
                    HttpResponse = (int)HttpStatusCode.OK,
                    Response = "Se ha actualizado la preventa exitosamente"
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
        public async Task<ResponseModel> DeletePreventa(string id)
        {
            ResponseModel response;

            try
            {
                await preventaService.DeletePreventa(id);

                response = new ResponseModel
                {
                    HttpResponse = (int)HttpStatusCode.OK,
                    Response = "Se ha eliminado preventa exitosamente"
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
