using AdministrativeService.DataBase;
using AdministrativeService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdministrativeService.Repository
{
    public class AdministartionRepository:IAdministratieRepository
    {
        private readonly DatabaseContext _databaseContext;
        public AdministartionRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<List<AdministrationPrices>> GetAllPrices()
        {
            try
            {
                return await _databaseContext.AdministrationPrices.ToListAsync();
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.Message);
                return new List<AdministrationPrices>();
            }
 
        }

        public async Task<ActionResult> PostPrice(AdministrationPrices administrationPrices)
        {
            try
            {
                _databaseContext.Add(administrationPrices);
                await _databaseContext.SaveChangesAsync();
                return default;
            }
            catch (Exception ex)
            {
                return default;
            }
         
        }

        public async Task<ActionResult> UpdatePrice(int id,AdministrationPrices administrationPrices)
        {
            try
            {
                
                var updatePrice = _databaseContext.AdministrationPrices.FirstOrDefault(n => n.Id == id);
                if (updatePrice != null)
                {
                    updatePrice.FuelType = administrationPrices.FuelType;
                    updatePrice.Price = administrationPrices.Price;
                    updatePrice.RoadType = administrationPrices.RoadType;
                    updatePrice.Timeframe = administrationPrices.Timeframe;
                    updatePrice.CarType = administrationPrices.CarType;
                    await _databaseContext.SaveChangesAsync();
                }
                
                return default;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default;
                throw;
            }
        }
    }
}
