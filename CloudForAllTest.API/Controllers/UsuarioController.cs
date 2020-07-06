using System;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using CloudForAllTest.API.Models;
using CloudForAllTest.Domain.Models;
using CloudForAllTest.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CloudForAllTest.API.Controllers
{
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> logger;
        private readonly IMapper mapper;
        private readonly IUserService userService;

        public UsuarioController(ILogger<UsuarioController> _logger,
                                  IUserService _userService,
                                  IMapper _mapper)
        {
            logger = _logger;
            mapper = _mapper;
            userService = _userService;
        }

        [HttpPost]
        public async Task<ResponseModel> Login(User user)
        {
            ResponseModel response;

            try
            {
                User userDB = mapper.Map<User>(user);
                string token = await userService.Login(userDB);

                response = new ResponseModel
                {
                    HttpResponse = (int)HttpStatusCode.OK,
                    Response = token
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
