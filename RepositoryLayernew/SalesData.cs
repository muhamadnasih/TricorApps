using DomainModel;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Interfaces;


namespace RepositoryLayer
{
    public class salesionData : ISalesData
    {
        private readonly ISqlDataAccess _sql;
        public salesionData(ISqlDataAccess sql)
        {
            this._sql = sql;
        }

        public async Task<IEnumerable<SalesDomainModel>> GetAllSales(string userId)
        {
            return await _sql.LoadData<SalesDomainModel, dynamic>("dbo.spSales_GetAllSales",
            new { UserId = userId }, "DefaultConnection");

        }


        public async Task<SalesDomainModel?> GetSpecificSales(string userId, int salesId)
        {

            var result = await _sql.LoadData<SalesDomainModel, dynamic>
                ("dbo.spSales_GetSpecificSales", new { UserId = userId, SalesId = salesId }, "DefaultConnection");
            return result.FirstOrDefault();

        }

        public async Task<SalesDomainModel?> CreateSales(string salesItem, DateTime salesDate, string userId, decimal amount, DateTime updateDate)
        {
            var results = await _sql.LoadData<SalesDomainModel, dynamic>("dbo.spSales_CreateSales",
                new { SalesItem = salesItem, SalesDate = salesDate, UserId = userId, Amount = amount, UpdateDate = updateDate },
                "DefaultConnection");

            return results.FirstOrDefault();

        }
        [HttpPost]
        public Task DeleteSales(string userId, int salesId)
        {
            return _sql.SaveData<dynamic>("dbo.spSales_DeleteSales",
                new { SalesId = salesId, UserId = userId },
                "DefaultConnection");
        }

        public Task UpdateSales(int salesId, string salesItem, string userId, decimal amount, DateTime updateDate)
        {
            return _sql.SaveData<dynamic>("dbo.spSales_UpdateSales",
               new { SalesId = salesId, SalesItem = salesItem, UserId = userId, Amount = amount, UpdateDate = updateDate },
               "DefaultConnection");
        }


    }
}
