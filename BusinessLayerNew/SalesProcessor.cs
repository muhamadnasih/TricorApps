using BusinessLayer.Interface;
using DomainModel;
using RepositoryLayer.Interfaces;


namespace BusinessLayer
{
    public class SalesProcessor : ISalesProcessor
    {
        private readonly ISalesData _salesdate;

        public SalesProcessor(ISalesData salesdata)
        {
            this._salesdate = salesdata;
        }

        public async Task<IEnumerable<SalesDomainModel>> GetAllSales(string userId)
        {
            var result = await _salesdate.GetAllSales(userId);

            return result;
        }

        public async Task<SalesDomainModel> GetSpecificSales(string userId, int salesId)
        {

            var result = await _salesdate.GetSpecificSales(userId, salesId);
            return result;

        }

        public async Task<SalesDomainModel?> CreateSales(string salesItem, DateTime salesDate, string userId, decimal amount, DateTime updateDate)
        {
            var result = await _salesdate.CreateSales(salesItem, salesDate, userId, amount, updateDate);

            return result;
        }

        public Task DeleteSales(string userId, int salesId)
        {
            return _salesdate.DeleteSales(userId, salesId);

        }

        public async Task<SalesDomainModel?> UpdateSales(int salesId, string salesItem, string userId, decimal amount, DateTime updateDate)
        {

            return await _salesdate.UpdateSales(salesId, salesItem, userId, amount, updateDate);

        }

        public async Task<IEnumerable<MonthlySalesReportDomainModel>> GetMonthlySalesReport(int selectedMonth, int selectedyear)
        {

            var result = await _salesdate.GetMonthlySalesReport(selectedMonth, selectedyear);
            return result;

        }








    }
}
