using AdministrativeService.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdministrativeService.Service
{
    public interface IAdministrationService
    {
        Task<ActionResult> CreateNewPrice(AdministrationPrices administrationPrices);
        Task<ActionResult> UpdatePrice(int id, AdministrationPrices administrationPrices);
        Task<List<AdministrationPrices>> GetAllPrices();

    }
}
