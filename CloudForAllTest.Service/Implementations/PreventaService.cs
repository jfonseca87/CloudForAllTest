using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CloudForAllTest.Domain;
using CloudForAllTest.Repository.Interfaces;
using CloudForAllTest.Service.Interfaces;

namespace CloudForAllTest.Service.Implementations
{
    public class PreventaService : IPreventaService
    {
        private readonly IPreventaRepository preventaRepository;

        public PreventaService(IPreventaRepository _preventaRepository)
        {
            preventaRepository = _preventaRepository;
        }

        public async Task CreatePreventa(Preventa preventa)
        {
            preventa.FechaPreventa = DateTime.UtcNow;
            await preventaRepository.CreatePreventa(preventa);
        }

        public async Task DeletePreventa(string id)
        {
            if (await preventaRepository.GetPreventa(id) == null)
            {
                return;
            }

            await preventaRepository.DeletePreventa(id);
        }

        public async Task<Preventa> GetPreventa(string id)
        {
            return await preventaRepository.GetPreventa(id);
        }

        public async Task<IEnumerable<Preventa>> GetPreventas()
        {
            return await preventaRepository.GetPreventas();
        }

        public async Task UpdatePreventa(Preventa preventa)
        {
            Preventa preventaUpdate = await preventaRepository.GetPreventa(preventa.PreventaId);

            if (preventaUpdate == null)
            {
                return;
            }

            preventaUpdate.FechaPreventa = preventa.FechaPreventa;
            preventaUpdate.LugarDespacho = preventa.LugarDespacho;

            await preventaRepository.UpdatePreventa(preventaUpdate);
        }
    }
}
