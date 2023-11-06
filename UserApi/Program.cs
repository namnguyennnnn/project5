using Microsoft.EntityFrameworkCore;
using UserApi.Data;
using UserApi.Repositiory.CommentRepo;
using UserApi.Repositiory.UserRepo;
using UserApi.Services;
using UserApi.Services.CommentService;
using UserApi.Services.FileService;
using UserApi.Services.UserService;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.SetIsOriginAllowed(_ => true) 
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
//DI
builder.Services.AddSingleton<IFileService, FileService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICommentService, CommentService>();


//auto mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGrpc();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");
app.UseHttpsRedirection();
PrepDb.PrepPopulation(app);
app.MapGrpcService<UserGrpcFunction>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
app.MapControllers();

app.Run();
