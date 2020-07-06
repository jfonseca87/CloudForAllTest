using System.Collections.Generic;
using System.Threading.Tasks;
using CloudForAllTest.Domain;

namespace CloudForAllTest.Service.Interfaces
{
    public interface IProductoService
    {
        Task<IEnumerable<Producto>> GetProductos();
        Task<Producto> GetProducto(string id);
        Task CreateProducto(Producto producto);
        Task UpdateProducto(Producto producto);
        Task DeleteProducto(string id);
    }
}
