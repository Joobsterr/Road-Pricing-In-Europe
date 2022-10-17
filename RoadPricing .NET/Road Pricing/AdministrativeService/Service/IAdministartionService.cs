using AdministrativeService.Models;

namespace AdministrativeService.Service
{
    public interface IAdministartionService
    {
        Task<bool> CreateNewPrice();
        Task<bool> UpdatePrice();
        Task<bool> DeletePrice();
        Task<List<AdministrationPrices>> GetAllPrices();
        Task<AdministrationPrices> GetPrice();

    }
}
