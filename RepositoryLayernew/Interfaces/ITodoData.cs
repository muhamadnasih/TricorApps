using DomainModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public interface ITodoData
    {
        Task CompleteTodo(int assignedTo, int todoId);
        Task<TodoModel?> Create(int assignedId, string task);
        Task Delete(int assignedTo, int todoId);
        Task<IEnumerable<TodoModel>> GetAllAssigned(int assignedId);
        Task<TodoModel?> GetOneAssigned(int assignedId, int todoId);
        Task UpdateTask(int assignedTo, int todoId, string task);
    }
}
