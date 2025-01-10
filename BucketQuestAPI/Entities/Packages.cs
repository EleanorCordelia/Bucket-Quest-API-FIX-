namespace BucketQuestAPI.Entities
{
    public class Package
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Detail { get; set; }
        
        public int Price { get; set; }

        public required Location Location { get; set; }

        public required Activity Activity { get; set; }

        public int ParticipantLimit { get; set; }

        public DateOnly DataRangeStart { get; set; }

        public DateOnly DataRangeEnd { get; set; }

        public TimeOnly ActivityTimeStart { get; set; }

        public TimeOnly ActivityTimeEnd { get; set; }

        public int Difficulty { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Photo? MainPhoto { get; set; }

        public List<Photo> Photos { get; set; } = new List<Photo>();
        
}}