using DomainModel;

namespace BusinessLayer.Interface
{
    public interface ITodoProcessor
    {
        Task<TodoModel> CreateTodo(string Task, int assigneeId, int assignerId);
    }

}