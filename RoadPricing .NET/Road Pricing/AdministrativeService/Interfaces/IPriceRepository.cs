using AdministrativeService.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdministrativeService.Interfaces
{
    public interface IPriceRepository
    {
        Task<List<AdministrationPrices>> GetPrices();
        Task<ActionResult> UpdatePrice(decimal price,int priceID);
        Task<ActionResult> CreatePrice(AdministrationPrices administrationPrices);

    }
}
