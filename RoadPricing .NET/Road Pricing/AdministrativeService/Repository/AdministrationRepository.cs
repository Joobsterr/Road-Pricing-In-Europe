using AdministrativeService.DataBase;
using AdministrativeService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdministrativeService.Repository
{
    public class AdministrationRepository : IAdministrationRepository
    {
        private readonly DatabaseContext _databaseContext;
        public AdministrationRepository(DatabaseContext databaseContext)
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

        public async Task<ActionResult?> PostPrice(AdministrationPrices administrationPrices)
        {
            try
            {
                AdministrationPrices insert=new AdministrationPrices { Price = administrationPrices.Price,CarType=administrationPrices.CarType,RoadType=administrationPrices.RoadType,FuelType=administrationPrices.FuelType,Timeframe=administrationPrices.Timeframe };
                _databaseContext.Add(insert);
                await _databaseContext.SaveChangesAsync();
                
                return default;
            }
            catch (Exception ex)
            {
                Console.WriteLine("---------------------Post Error Admin----------------------");
                Console.WriteLine($"error message:{ex.Message}");
                Console.WriteLine("-------------------------End Error-------------------------");
                return null;
            }
         
        }

        public async Task<ActionResult?> UpdatePrice(int id,AdministrationPrices administrationPrices)
        {
            try
            {
                
                var updatePrice = _databaseContext.AdministrationPrices.FirstOrDefault(n => n.Id == id);
                if (updatePrice != null)
                {
                    updatePrice.FuelType = administrationPrices.FuelType;
                    updatePrice.Price = administrationPrices.Price;
                    updatePrice.RoadType = administrationPrices.RoadType;
                   // updatePrice.Timeframe = administrationPrices.Timeframe;
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
