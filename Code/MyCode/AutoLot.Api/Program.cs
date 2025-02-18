var builder = WebApplication.CreateBuilder(args);
builder.ConfigureSerilog();
builder.Services.RegisterLoggingInterfaces();

// Add services to the container.

builder.Services.AddControllers(
config => config.Filters.Add(new CustomExceptionFilterAttribute(builder.Environment))
)
.AddJsonOptions(options => {
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    options.JsonSerializerOptions.WriteIndented = true;
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
})
.ConfigureApiBehaviorOptions(options =>
{
    //suppress automatic model state binding errors
    options.SuppressModelStateInvalidFilter = true;
    //suppress all binding inference
    //options.SuppressInferBindingSourcesForParameters= true;
    //suppress multipart/form-data content type inference
    //options.SuppressConsumesConstraintForFormFileParameters = true;
    //Don't create a problem details error object if set to true
    options.SuppressMapClientErrors = false;
    options.ClientErrorMapping[StatusCodes.Status404NotFound].Link = "https://httpstatuses.com/404";
    options.ClientErrorMapping[StatusCodes.Status404NotFound].Title = "Invalid location";
});
var connectionString = builder.Configuration.GetConnectionString("AutoLot");
builder.Services.AddDbContextPool<ApplicationDbContext>(
options => {
    options.ConfigureWarnings(wc => wc.Ignore(RelationalEventId.BoolWithDefaultWarning));
    options.UseSqlServer(connectionString,
    sqlOptions => sqlOptions.EnableRetryOnFailure().CommandTimeout(60));
});

// Add the repos
builder.Services.AddScoped<ICarDriverRepo, CarDriverRepo>();
builder.Services.AddScoped<ICarRepo, CarRepo>();
builder.Services.AddScoped<IDriverRepo, DriverRepo>();
builder.Services.AddScoped<IMakeRepo, MakeRepo>();
builder.Services.AddScoped<IRadioRepo, RadioRepo>();

builder.Services.AddAutoLotApiVersionConfiguration(new ApiVersion(1, 0));

// Add CORS
// NOTE: Production applications must be locked down and not wide open like this
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", pb =>
    {
        pb
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddAndConfigureSwagger(
builder.Configuration,
Path.Combine(AppContext.BaseDirectory,
$"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
    options =>
    {
        foreach (var description in app.DescribeApiVersions())
        {
            var url = $"/swagger/{description.GroupName}/swagger.json";
            var name = $"AutoLot API: {description.GroupName.ToUpperInvariant()}";
            options.SwaggerEndpoint(url, name);
        }
    });
    //Initialize the database
    if (app.Configuration.GetValue<bool>("RebuildDataBase"))
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        SampleDataInitializer.ClearAndReseedDatabase(dbContext);
    }
}

app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
