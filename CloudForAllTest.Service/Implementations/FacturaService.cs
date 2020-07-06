using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CloudForAllTest.Domain;
using CloudForAllTest.Domain.Models.DTOs;
using CloudForAllTest.Repository.Interfaces;
using CloudForAllTest.Service.Interfaces;

namespace CloudForAllTest.Service.Implementations
{
    public class FacturaService : IFacturaService
    {
        private readonly IFacturaRepository facturaRepository;
        private readonly IProductoRepository productoRepository;
        private readonly IPreventaRepository preventaRepository;

        public FacturaService(IFacturaRepository _facturaRepository,
                              IProductoRepository _productoRepository,
                              IPreventaRepository _preventaRepository)
        {
            facturaRepository = _facturaRepository;
            productoRepository = _productoRepository;
            preventaRepository = _preventaRepository;
        }

        public async Task<Factura> CreateFactura(FacturaDTO factura)
        {
            Producto producto = await productoRepository.GetProducto(factura.ProductoId);

            if (producto == null)
            {
                return null;
            }

            Preventa preventa = await preventaRepository.GetPreventa(factura.PreventaId);

            if (preventa == null)
            {
                return null;
            }

            Factura nuevaFactura = new Factura
            {
                Preventa = preventa,
                Producto = producto,
                FacturaFecha = DateTime.UtcNow,
                Cantidad = factura.CantidadProducto,
                Total = producto.ValorUnitario * factura.CantidadProducto
            };

            return await facturaRepository.CreateFactura(nuevaFactura);
        }

        public async Task<IEnumerable<Factura>> GetFacturas()
        {
            return await facturaRepository.GetFacturas();
        }
    }
}
