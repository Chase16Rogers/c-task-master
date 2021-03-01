namespace task_master_api.Models
{
    public class Task
    {
        public int id { get; set; }
        public string creatorId { get; set; }
        public string task { get; set; }
        public int listId { get; set; }
        public bool done { get; set; }
    }
}