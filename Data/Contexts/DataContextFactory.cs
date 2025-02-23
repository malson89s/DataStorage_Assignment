using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Data.Contexts;

namespace Data.Contexts;

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();

        optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projects\DataStorage_Assignment\Data\Databases\local_database.mdf;Integrated Security=True");

        return new DataContext(optionsBuilder.Options);
    }

}

