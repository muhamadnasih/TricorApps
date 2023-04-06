using DomainModel;

namespace RepositoryLayer.Interfaces
{
    public interface ISalesData
    {
        Task<SalesDomainModel?> CreateSales(string salesItem, DateTime salesDate, string userId, decimal amount, DateTime updateDate);
        Task DeleteSales(string userId, int salesId);
        Task<IEnumerable<SalesDomainModel>> GetAllSales(string userId);
        Task<SalesDomainModel?> GetSpecificSales(string userId, int salesId);
        Task UpdateSales(int salesId, string salesItem, string userId, decimal amount, DateTime updateDate);
    }
}