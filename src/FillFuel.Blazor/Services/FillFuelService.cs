using Azure;
using Azure.Data.Tables;
using FillFuel.Blazor.Models;

namespace FillFuel.Blazor.Services;

public class FillFuelService : IFillFuelService
{
    string tableConnectionString = "DefaultEndpointsProtocol=https;AccountName=fillfuel;AccountKey=obd/C2EuFarxgvkowa0L0+p5h5kDTn9AgG7g7tEKK8SyEuenQhTwReQaqoirqa7njrmtmjPPBlY4+ASttXo/Lg==;EndpointSuffix=core.windows.net";
    string partitionKey = "arahk@outlook.com";

    public async Task EntryAsync(double amount)
    {
        TableServiceClient tsc = new TableServiceClient(tableConnectionString);
        TableClient tc = tsc.GetTableClient("FuelEntry");

        string rowKey = Guid.NewGuid().ToString();

        FuelEntryTableEntity fuelEntryTableEntity = new()
        {
            PartitionKey = partitionKey,
            RowKey = rowKey,
            Amount = amount
        };

        await tc.AddEntityAsync(fuelEntryTableEntity);
    }

    public async Task DeleteAsync(string rowKey)
    {
        TableServiceClient tsc = new TableServiceClient(tableConnectionString);
        TableClient tc = tsc.GetTableClient("FuelEntry");

        await tc.DeleteEntityAsync(partitionKey, rowKey);
    }

    public async Task<FuelEntryTableEntity> GetAsync(string rowKey)
    {
        TableServiceClient tsc = new TableServiceClient(tableConnectionString);
        TableClient tc = tsc.GetTableClient("FuelEntry");

        FuelEntryTableEntity entity = await tc.GetEntityAsync<FuelEntryTableEntity>("arahk@outlook.com", rowKey);

        return entity;
    }

    public async IAsyncEnumerable<FuelEntryTableEntity> ListAsync()
    {
        TableServiceClient tsc = new TableServiceClient(tableConnectionString);
        TableClient tc = tsc.GetTableClient("FuelEntry");

        AsyncPageable<FuelEntryTableEntity> entityPages = tc.QueryAsync<FuelEntryTableEntity>(p => p.PartitionKey == partitionKey);

        await foreach (FuelEntryTableEntity entity in entityPages)
        {
            yield return entity;
        }
    }
}