namespace AutoLot.Dal.EfStructures;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
		var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
		var cs = @"Server=localhost\MSSQLSERVER02;Database=master;Trusted_Connection=True;Encrypt=False;";
		optionsBuilder.UseSqlServer(cs);
		optionsBuilder.ConfigureWarnings(cw => cw.Ignore(RelationalEventId.BoolWithDefaultWarning));
		Console.WriteLine(cs);
		return new ApplicationDbContext(optionsBuilder.Options);
    }
}
