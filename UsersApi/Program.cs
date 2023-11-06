using Microsoft.EntityFrameworkCore;
using UsersApi.Data;
using UsersApi.Repositiory.CommentRepo;
using UsersApi.Repositiory.UserRepo;
using UsersApi.Services;


var builder = WebApplication.CreateBuilder(args);

var dbHost = "localhost";
var dbName = "toeic-db";
var dbPassword = "123456";
var ConectionString = $"server={dbHost};port=3306;database={dbName};user=root;password={dbPassword};";
builder.Services.AddDbContext<DataContext>(o => o.UseMySQL(ConectionString));

//DI

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<ICommentRepository, CommentRepository>();


//auto mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<UserGrpcFunction>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
