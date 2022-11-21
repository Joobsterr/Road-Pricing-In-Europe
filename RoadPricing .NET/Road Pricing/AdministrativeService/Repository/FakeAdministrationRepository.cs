using AdministrativeService.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdministrativeService.Repository
{
    public class FakeAdministrationRepository : IAdministrationRepository
    {
        public Task<List<AdministrationPrices>> GetAllPrices()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult> PostPrice(AdministrationPrices administrationPrices)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult> UpdatePrice(int id, AdministrationPrices administrationPrices)
        {
            throw new NotImplementedException();
        }
    }
}
