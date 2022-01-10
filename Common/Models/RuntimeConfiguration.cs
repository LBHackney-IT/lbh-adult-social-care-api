namespace Common.Models
{
    public class RuntimeConfiguration
    {
        public const string SectionName = "RuntimeConfiguration";
        public bool IsSqlite { get; set; }
        public bool IsQueueAvailable { get; set; }
    }
}
