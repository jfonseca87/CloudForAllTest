using System.Collections.Generic;
using System.Threading.Tasks;
using CloudForAllTest.Domain;

namespace CloudForAllTest.Service.Interfaces
{
    public interface IPreventaService
    {
        Task<IEnumerable<Preventa>> GetPreventas();
        Task<Preventa> GetPreventa(string id);
        Task CreatePreventa(Preventa preventa);
        Task UpdatePreventa(Preventa preventa);
        Task DeletePreventa(string id);
    }
}
