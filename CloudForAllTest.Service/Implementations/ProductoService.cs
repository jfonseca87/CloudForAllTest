using System.Collections.Generic;
using System.Threading.Tasks;
using CloudForAllTest.Domain;
using CloudForAllTest.Repository.Interfaces;
using CloudForAllTest.Service.Interfaces;

namespace CloudForAllTest.Service.Implementations
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository productoRepository;

        public ProductoService(IProductoRepository _productoRepository)
        {
            productoRepository = _productoRepository;
        }

        public async Task CreateProducto(Producto producto)
        {
            await productoRepository.CreateProducto(producto);
        }

        public async Task DeleteProducto(string id)
        {
            if (await productoRepository.GetProducto(id) == null)
            {
                return;
            }

            await productoRepository.DeleteProducto(id);
        }

        public async Task<Producto> GetProducto(string id)
        {
            return await productoRepository.GetProducto(id);
        }

        public async Task<IEnumerable<Producto>> GetProductos()
        {
            return await productoRepository.GetProductos();
        }

        public async Task UpdateProducto(Producto producto)
        {
            Producto productoUpdate = await productoRepository.GetProducto(producto.ProductoId);

            if (productoUpdate == null)
            {
                return;
            }

            productoUpdate.NomProducto = producto.NomProducto;
            productoUpdate.ValorUnitario = producto.ValorUnitario;

            await productoRepository.UpdateProducto(productoUpdate);
        }
    }
}
