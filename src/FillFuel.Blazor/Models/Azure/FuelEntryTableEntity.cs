using Azure;
using Azure.Data.Tables;

namespace FillFuel.Blazor.Models;

public class FuelEntryTableEntity : ITableEntity
{
    public string PartitionKey { get; set; } = string.Empty;
    public string RowKey { get; set; } = string.Empty;
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }

    public double Amount { get; set; }
}