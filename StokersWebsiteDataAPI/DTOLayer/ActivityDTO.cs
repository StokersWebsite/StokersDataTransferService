namespace DTOLayer
{
    public class ActivityDTO
    {
        public string? name { get; set; }
        public string? description { get; set; }
        public DateOnly? date { get; set; }
        public string? location { get; set; }
        public string? MaxMembers { get; set; }
    }
}