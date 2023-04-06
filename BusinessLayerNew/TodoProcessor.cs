using BusinessLayer.Interface;
using DomainModel;
using RepositoryLayer;




namespace BusinessLayer
{
    public class TodoProcessor : ITodoProcessor
    {
        private readonly ITodoData _data;
        public TodoProcessor(ITodoData data)
        {
            this._data = data;
        }

        public async Task<TodoModel> CreateTodo(string Task, int assigneeId, int assignerId)
        {
            var todo = await CreateTodo(Task, assigneeId, assignerId);

            return todo;

        }

        //public static List<TodoModel> GetSpecificTodo(int todoId)
        //{


        //}

    }
}
