using System.Collections.Generic;

namespace task_master_api.Models
{
    public class List
    {
        public int id { get; set; }
        public string name { get; set; }
        public string creatorId { get; set; }
    }

    public class ListTaskViewModel : List
    {
        public List<Task> listTasks {get; set;} = new List<Task>();
    }
}