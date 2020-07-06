using System.Collections.Generic;
using System.Threading.Tasks;
using CloudForAllTest.Domain;

namespace CloudForAllTest.Repository.Interfaces
{
    public interface IFacturaRepository
    {
        Task<IEnumerable<Factura>> GetFacturas();
        Task<Factura> CreateFactura(Factura factura);
    }
}
