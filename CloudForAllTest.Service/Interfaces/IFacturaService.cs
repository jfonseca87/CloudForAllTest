using System.Collections.Generic;
using System.Threading.Tasks;
using CloudForAllTest.Domain;
using CloudForAllTest.Domain.Models.DTOs;

namespace CloudForAllTest.Service.Interfaces
{
    public interface IFacturaService
    {
        Task<IEnumerable<Factura>> GetFacturas();
        Task<Factura> CreateFactura(FacturaDTO factura);
    }
}
