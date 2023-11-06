using CategoryApi.Data;
using CategoryApi.Repository.Category;
using CategoryApi.Repository.CategoryDetails;
using CategoryApi.Services;
using CategoryApi.Services.CategoryDetailSV;
using CategoryApi.Services.CategorySV;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//builder.WebHost.UseKestrel().UseUrls("https://localhost:7075").UseIISIntegration();
// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.SetIsOriginAllowed(_ => true) // Cho phép tất cả các nguồn gốc
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
});

if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
{
    
    var dbHost = "localhost";
    var dbName = "toeic-db";
    var dbPassword = "123456";
    var dbPort = "3306";
    var ConectionString = $"server={dbHost};port={dbPort};database={dbName};user=root;password={dbPassword};";
    builder.Services.AddDbContext<DataContext>(o => o.UseMySQL(ConectionString));
}
else
{
    var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
    var dbName = Environment.GetEnvironmentVariable("DB_NAME");
    var dbPassword = Environment.GetEnvironmentVariable("MYSQL_ROOT_PASSWORD");
    var dbPort = Environment.GetEnvironmentVariable("DB_PORT");
    var ConectionString = $"server={dbHost};port={dbPort};database={dbName};user=root;password={dbPassword};";
    builder.Services.AddDbContext<DataContext>(o => o.UseMySQL(ConectionString));
}


//Deopendency injection 
builder.Services.AddScoped<ICategoryServices, CategoryServices>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();


builder.Services.AddScoped<ICategoryDetailService, CategoryDetailService>();
builder.Services.AddScoped<ICategoryDetailsRepository, CategoryDetailsRepository>();


builder.Services.AddGrpc();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{  
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.MapGrpcService<CategoryDetailGrpcFunction>();
app.UseCors("AllowAll");
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
PrepDb.PrepPopulation(app);
app.UseHttpsRedirection();

app.MapControllers();

app.Run();
