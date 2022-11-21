using AdministrativeService.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdministrativeService.Repository
{
    public interface IAdministrationRepository
    {
        Task<ActionResult> PostPrice(AdministrationPrices administrationPrices);
        Task<ActionResult> UpdatePrice(int id, AdministrationPrices administrationPrices);
        Task<List<AdministrationPrices>> GetAllPrices();
    }
}
