using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using serversidevalidation;

namespace tests;

public class Setup
{
    protected IServiceProvider ServiceProvider { get; }

    public Setup()
    {
        var services = new ServiceCollection();
        Program.ConfigureServices(services);
        services.RemoveAll(typeof(MyDbContext));
        var connection = new SqliteConnection("Filename=:memory:");
        connection.Open();
        var contextOptions = new DbContextOptionsBuilder<MyDbContext>()
            .UseSqlite()
            .Options;

        //add to DI        
        ServiceProvider = services.BuildServiceProvider();
    }

    protected T GetService<T>() where T : notnull
    {
        using var scope = ServiceProvider.CreateScope();
        return scope.ServiceProvider.GetRequiredService<T>();
    }

  
}