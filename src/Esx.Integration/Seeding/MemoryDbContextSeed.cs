
using System.Globalization;

using CsvHelper;
using CsvHelper.Configuration;

using Esx.Domain;

using Microsoft.EntityFrameworkCore;

namespace Esx.Integration.Seeding;
public  class MemoryDbContextSeed(string contentRootPath, string seedingConfig)
{
    public static Func<DbContext, bool, CancellationToken, Task> Create(string contentRootPath, string seedingConfig)
        => new MemoryDbContextSeed(contentRootPath, seedingConfig).SeedDemoData;
    public async Task SeedDemoData(DbContext dbContext, bool _, CancellationToken cancellationToken)
    {
        dbContext.AddRange(ReadCsvFile<RentRecord>());
        await dbContext.SaveChangesAsync(cancellationToken);
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
