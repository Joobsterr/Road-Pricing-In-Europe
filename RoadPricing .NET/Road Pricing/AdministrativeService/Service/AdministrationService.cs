using AdministrativeService.DataBase;
using AdministrativeService.Models;
using AdministrativeService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AdministrativeService.Service
{
    public class AdministrationService : IAdministrationService
    {
        private readonly IAdministrationRepository _administratieRepository;
        public AdministrationService(IAdministrationRepository administratieRepository)
        {
            _administratieRepository = administratieRepository;
        }

        public async Task<ActionResult> CreateNewPrice(AdministrationPrices administrationPrices)
        {
            return await _administratieRepository.PostPrice(administrationPrices);
        }

        public async Task<List<AdministrationPrices>> GetAllPrices()
        {
            return await _administratieRepository.GetAllPrices();
        }

        public async Task<ActionResult> UpdatePrice(int id, AdministrationPrices administrationPrices)
        {
            return await _administratieRepository.UpdatePrice(id,administrationPrices);
        }
    }
}
