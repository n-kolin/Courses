using Courses.Core.InterfaceRepositories;
using Courses.Core.InterfaceServices;
using Courses.Data;
using Courses.Data.Repositories;
using Courses.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Student
builder.Services.AddScoped<IStudentRepository,StudentRepository>();
builder.Services.AddScoped<IStudentService,StudentService>();
//Course
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ICourseService, CourseService>();
//Lesson
builder.Services.AddScoped<ILessonRepository,LessonRepository>();
builder.Services.AddScoped<ILessonService, LessonService>();
//Teacher
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
//StudentInCourse
builder.Services.AddScoped<IStudentInCourseRepository, StudentInCourseRepository>();
builder.Services.AddScoped<IStudentInCourseService, StudentInCourseService>();


builder.Services.AddDbContext<DataContext>(option =>
{
    option.UseSqlServer("Data Source = DESKTOP-SSNMLFD; Initial Catalog = Courses; Integrated Security = true;");
});
//builder.Services.AddSingleton<DataContext>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
