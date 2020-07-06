using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using CloudForAllTest.API.Models;
using CloudForAllTest.Domain;
using CloudForAllTest.Domain.Models.DTOs;
using CloudForAllTest.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CloudForAllTest.API.Controllers
{
    [ApiController]
    [Route("api/factura")]
    public class FacturaController : ControllerBase
    {
        private readonly ILogger<FacturaController> logger;
        private readonly IMapper mapper;
        private readonly IFacturaService facturaService;

        public FacturaController(ILogger<FacturaController> _logger,
                                  IFacturaService _facturaService,
                                  IMapper _mapper)
        {
            logger = _logger;
            mapper = _mapper;
            facturaService = _facturaService;
        }

        [HttpGet]
        public async Task<ResponseModel> GetFacturas()
        {
            ResponseModel response;

            try
            {
                IEnumerable<Factura> facturas = await facturaService.GetFacturas();
                IEnumerable<FacturaApiModelRead> facturasResponse = mapper.Map<List<FacturaApiModelRead>>(facturas);

                response = new ResponseModel
                {
                    HttpResponse = (int)HttpStatusCode.OK,
                    Response = facturasResponse
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
        public async Task<ResponseModel> CreateFactura(FacturaApiModel factura)
        {
            ResponseModel response;

            try
            {
                FacturaDTO facturaCreate = mapper.Map<FacturaDTO>(factura);
                Factura facturaResult = await facturaService.CreateFactura(facturaCreate);

                if (facturaResult == null)
                {
                    FacturaReponseModel facturaResponse = new FacturaReponseModel
                    {
                        ProcesoVenta = "Fallido"
                    };

                    response = new ResponseModel
                    {
                        HttpResponse = (int)HttpStatusCode.BadRequest,
                        Response = facturaResponse
                    };
                }
                else
                {
                    FacturaReponseModel facturaResponse = mapper.Map<FacturaReponseModel>(facturaResult);
                    facturaResponse.ProcesoVenta = "Exitoso";

                    response = new ResponseModel
                    {
                        HttpResponse = (int)HttpStatusCode.Created,
                        Response = facturaResponse
                    };
                }

                
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
