using ExercisesApi.Data;
using ExercisesApi.Repository.AnswerRepo;
using ExercisesApi.Repository.AudioRepo;
using ExercisesApi.Repository.ExamResultDetailRepo;
using ExercisesApi.Repository.ExamResultRepo;
using ExercisesApi.Repository.ExerciseRepo;
using ExercisesApi.Repository.ImageRepo;
using ExercisesApi.Repository.ParagraphRepo;
using ExercisesApi.Repository.QuestionRepo;
using ExercisesApi.Services;
using ExercisesApi.Services.AudioService;
using ExercisesApi.Services.ExerciseService;
using ExercisesApi.Services.FileService;
using ExercisesApi.Services.ImageService;
using ExercisesApi.Services.ParagraphService;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

//Config mysql db
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
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
builder.Services.AddScoped<IExerciseServices, ExerciseServices>();

builder.Services.AddScoped<IAnswerRepository, AnswerRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();

builder.Services.AddScoped<IAudioRepository, AudioRepository>();
builder.Services.AddScoped<IAudioService, AudioService>();


builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<IImageService, ImageService>();

builder.Services.AddScoped<IParagraphRepository, ParagraphRepository>();
builder.Services.AddScoped<IParagraphService, ParagraphService>();

builder.Services.AddScoped<IExamResultRepository, ExamResultRepository>();

builder.Services.AddScoped<IExamResultDetailRepository, ExamResultDetailRepository>();


builder.Services.AddSingleton<IFileService, FileService>();


//auto mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
builder.Services.AddGrpc();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<FormOptions>(options =>
{
    options.ValueCountLimit = 157286400; 
});
var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapGrpcService<ExerciseGrpcFunction>();
app.UseCors("AllowAll");
PrepDb.PrepPopulation(app);
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
app.MapControllers();
app.Run();