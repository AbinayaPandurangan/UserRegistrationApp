using Podme.UserRegistrationApp.Api.Configurations;
using Podme.UserRegistrationApp.Api.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureSwagger();

var logger = new LoggerConfiguration().MinimumLevel.Information()
    .WriteTo.File("log/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
Log.Logger = logger;
builder.Host.UseSerilog();

//builder.Services.AddDbContext<DataContext>(opt =>
//{
//    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Podme.UserRegistrationApp.Api"));
//});

builder.Services.ConfigureSqlLite(builder.Configuration);
builder.Services.ConfigureAppServices();

//builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.ConfigureAutoMapper();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI(options=>
    //{
    //    options.SwaggerEndpoint("/swagger/v1/swagger.json", "User Registration");
    //    options.RoutePrefix = string.Empty;
    //});
    app.UseSwaggerConfig();
}

app.MapControllers();

app.UseCors(opt =>
{
    app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000"));
});

//var scope = app.Services.CreateScope();
//var context = scope.ServiceProvider.GetRequiredService<DataContext>();

//try
//{
//    context.Database.Migrate();
//    DbInitializer.Initialize(context);
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message, "A problem occured during migration.");
//}

app.ExecuteDataMigrate();

app.Run();
