namespace Hless.Data.Models.Dto
{
    public record SchemaDto
    {
        public long SchemaId { get; init; }
        public string Name { get; init; }
        public string Definition { get; init; }
        public string DraftDefinition { get; init; }
        public string CreatedBy { get; init; }

    }
}