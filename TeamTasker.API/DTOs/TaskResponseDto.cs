namespace TeamTasker.API.DTOs
{
    public record TaskResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;        
        public DateTime CreatedAt { get; set; } 
        
        public UserSummaryDto User { get; set; } = new();
    }

    public record UserSummaryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}