
using CategoryService.Data;
using CategoryService.Repository.Category;
using CategoryService.Repository.CategoryDetails;
using CategoryService.Services;
using CategoryService.Services.CategoryDetailSV;
using CategoryService.Services.CategorySV;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

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

//Config mysql db
//var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
//var dbName = Environment.GetEnvironmentVariable("DB_NAME");
//var dbPassword = Environment.GetEnvironmentVariable("DB_ROOT_PASSWORD");
var dbHost = "localhost";
var dbName = "db-category";
var dbPassword = "123456";
var ConectionString = $"server={dbHost};port=3306;database={dbName};user=root;password={dbPassword};";
builder.Services.AddDbContext<DataContext>(o => o.UseMySQL(ConectionString));


//Deopendency injection 
builder.Services.AddScoped<ICategoryServices, CategoryServices>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();


builder.Services.AddScoped<ICategoryDetailService, CategoryDetailService>();
builder.Services.AddScoped<ICategoryDetailsRepository, CategoryDetailsRepository>();


builder.Services.AddGrpc();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

PrepDb.PrepPopulation(app);
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapGrpcService<CategoryDetailGrpcFunction>();
app.UseCors("AllowAll");
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
app.MapControllers();
app.Run();
