
using System.Collections.Generic;
using System.Threading.Tasks;


namespace RepositoryLayer
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName);
        Task SaveData<T>(string storedProcedure, T parameters, string connectionStringName);

    }
}
