using FillFuel.Blazor.Models;

namespace FillFuel.Blazor.Services;
public interface IFillFuelService 
{
    Task EntryAsync(double amount);
    Task DeleteAsync(string rowKey);
    Task<FuelEntryTableEntity> GetAsync(string rowKey);
    IAsyncEnumerable<FuelEntryTableEntity> ListAsync();
}