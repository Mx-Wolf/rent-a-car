
using System.Globalization;

using CsvHelper;
using CsvHelper.Configuration;

using Esx.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace Esx.Integration.Seeding;
public  class MemoryDbContextSeed(string contentRootPath, string seedingConfig)
{
    public static Func<DbContext, bool, CancellationToken, Task> Create(string contentRootPath, string seedingConfig)
        => new MemoryDbContextSeed(contentRootPath, seedingConfig).SeedDemoDataAsync;
    public static Action<DbContext, bool> CreateSeeder(string contentRootPath, string seedingConfig)
        => new MemoryDbContextSeed(contentRootPath, seedingConfig).SeedingDemoData;
    public async Task SeedDemoDataAsync(DbContext dbContext, bool _, CancellationToken cancellationToken)
    {
        var items = ReadCsvFile<RentRecord>();
        var ids = items.Select(i=>i.Id.Value).ToList();
        var known = await dbContext.Set<RentRecord>().Where(i => ids.Contains(i.Id)).ToListAsync();
        foreach(var item in items)
        {
            if (!known.Any(k=>k.Id==item.Id))
            {
                dbContext.Add(item);
            }
        }
        await dbContext.SaveChangesAsync(cancellationToken);
    }
    public void SeedingDemoData(DbContext dbContext, bool flag)
    {
        SeedDemoDataAsync(dbContext, flag, CancellationToken.None).Wait();
    }

    private T[] ReadCsvFile<T>()
    {
        var path = Path.Combine(contentRootPath, seedingConfig, Path.ChangeExtension(typeof(T).Name, ".csv"));
        var options = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true
        };
        using var textReader = File.OpenText(path);
        var csvReader = new CsvReader(textReader, options);
        return csvReader.GetRecords<T>().ToArray();
    }
}
