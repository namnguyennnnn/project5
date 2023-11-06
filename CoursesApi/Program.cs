using CoursesApi.Data;
using CoursesApi.Repository.CourseDetailRepo;
using CoursesApi.Repository.CourseRepo;
using CoursesApi.Repository.EnrollmentRepo;
using CoursesApi.Repository.InstructorRepo;
using CoursesApi.Repository.LectureRepo;
using CoursesApi.Repository.RatingRepo;
using CoursesApi.Services.CourseService;
using CoursesApi.Services.FileService;
using CoursesApi.Services.InstructorService;
using CoursesApi.Services.RatingService;
using Microsoft.EntityFrameworkCore;

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

builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ICourseService, CourseService>();

builder.Services.AddScoped<ICourseDetaiRepository, CourseDetaiRepository>();
builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();


builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();
builder.Services.AddScoped<IInstructorService, InstructorService>();

builder.Services.AddScoped<ILectureRepository, LectureRepository>();

builder.Services.AddScoped<IRatingRepository, RatingRepository>();
builder.Services.AddScoped<IRatingService, RatingService>();

builder.Services.AddSingleton<IFileService, FileService>();

//auto mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
PrepDb.PrepPopulation(app);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.MapControllers();

app.Run();
