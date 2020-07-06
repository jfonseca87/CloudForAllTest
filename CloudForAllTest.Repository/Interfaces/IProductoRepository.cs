using System.Collections.Generic;
using System.Threading.Tasks;
using CloudForAllTest.Domain;

namespace CloudForAllTest.Repository.Interfaces
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetProductos();
        Task<Producto> GetProducto(string id);
        Task CreateProducto(Producto producto);
        Task UpdateProducto(Producto producto);
        Task DeleteProducto(string id);
    }
}
