namespace Esx.Domain.Entities;

public class OutboxRecord
{
    public int Id { get; init; }
    public DateTime DatePublished { get; init; }

    public required string EventInfo { get; init; }

    private OutboxRecord(){}

    public OutboxRecord(DateTime datePublished, string eventInfo)
    {
        DatePublished = datePublished;
        EventInfo = eventInfo;
    }
}