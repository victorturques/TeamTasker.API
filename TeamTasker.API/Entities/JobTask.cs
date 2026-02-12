using TeamTasker.API.Enums;

namespace TeamTasker.API.Entities
{
    public class JobTask
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;       
        public TaskStatusEnum Status { get; set; } = TaskStatusEnum.Pendente;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
       public int UserId { get; set; }        
        public User? User { get; set; }
    }
}