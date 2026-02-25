namespace task_manager_api.Contracts.Requests.DTO
{
    public class TasksDTO
    {
        public int UserId { get; set; }
        public string? Title { get; set; }
        public bool isDone { get; set; }
    }
}
