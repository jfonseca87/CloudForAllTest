using System;
using System.Linq;
using CloudForAllTest.Domain;
using CloudForAllTest.Domain.Models;
using CloudForAllTest.Service.Interfaces;
using CloudForAllTest.Service.Utilities;
using DnsClient.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CloudForAllTest.API.Utilities
{
    public class SeedData
    {
        private readonly ServiceProvider services;

        public SeedData(IServiceCollection _services)
        {
            services = _services.BuildServiceProvider();
        }

        public void SeedFirstData()
        {
            SeedUsuariosData();
            SeedPreventaData();
            SeedProductoData();
        }

        private async void SeedUsuariosData()
        {
            var logger = services.GetService<ILogger<SeedData>>();
            var userService = services.GetService<IUserService>();

            try
            {
                bool hasData = await userService.ExistsUsers();
                if (hasData)
                {
                    return;
                }

                User user = new User
                {
                    NomUser = "Admin",
                    Contrasena = Password.CreateMD5Password("Admin123"),
                    Activo = true,
                    Rol = "Admin"
                };

                await userService.CreateUser(user);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
        }

        private async void SeedPreventaData()
        {
            var logger = services.GetService<ILogger<SeedData>>();
            var preventaService = services.GetService<IPreventaService>();

            try
            {
                var preventas = await preventaService.GetPreventas();
                if (preventas.Any())
                {
                    return;
                }

                Preventa preventa = new Preventa
                {
                    LugarDespacho = "Bogota",
                    FechaPreventa = DateTime.UtcNow,
                    Email = "user@domain.com"
                };

                await preventaService.CreatePreventa(preventa);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
        }

        private async void SeedProductoData()
        {
            var logger = services.GetService<ILogger<SeedData>>();
            var productoService = services.GetService<IProductoService>();

            try
            {
                var productos = await productoService.GetProductos();
                if (productos.Any())
                {
                    return;
                }

                Producto producto = new Producto
                {
                    NomProducto = "Monitor 29 Pulgadas",
                    ValorUnitario = 250.25m
                };

                await productoService.CreateProducto(producto);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
        }
    }
}
