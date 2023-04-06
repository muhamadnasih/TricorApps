
using DomainModel;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class TodoData : ITodoData
    {
        private readonly ISqlDataAccess _sql;

        public TodoData(ISqlDataAccess sql)
        {
            this._sql = sql;
        }

        public async Task<IEnumerable<TodoModel>> GetAllAssigned(int userId)
        {
            string query = "select";
            //return _sql.LoadData<TodoModel,dynamic>(query,assignedId,"Default");
            return await _sql.LoadData<TodoModel, dynamic>("dbo.spTodo_GetAllAssigned",
             userId ,
             "Default");
        }


        public async Task<TodoModel?> GetOneAssigned(int assignedId, int todoId)
        {
          
            var result = await _sql.LoadData<TodoModel,dynamic>
                ("", new { AssignedTo = assignedId, TodoId = todoId },"Default");
           
            return result.FirstOrDefault();
          
        }

        public async Task<TodoModel?> Create(int assignedId, string task)
        {
            var results = await _sql.LoadData<TodoModel, dynamic>("dbo.spTodo_Create",
                new { AssignedTo = assignedId, Task = task },
                "Default");

            return results.FirstOrDefault();

        }

        public Task CompleteTodo(int assignedTo, int todoId)
        {
            return _sql.SaveData<dynamic>("dbo.spTodo_CompletTodo",
                new { AssignedTo = assignedTo, TdoId = todoId },
                "Default");
        }

        public Task Delete(int assignedTo, int todoId)
        {
            return _sql.SaveData<dynamic>("dbo.spTodo_Delete",
                new { AssignedTo = assignedTo, TdoId = todoId },
                "Default");
        }

        public Task UpdateTask(int assignedTo, int todoId, string task)
        {
            return _sql.SaveData<dynamic>("dbo.spTodo_Delete",
               new { AssignedTo = assignedTo, TdoId = todoId },
               "Default");
        }
    }
}
