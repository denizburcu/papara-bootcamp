using OwnerProject.Api.Extensions;
using OwnerProject.Api.Middlewares;
using OwnerProject.Data.Context;
using OwnerProject.Services.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<OwnerDapperContext>();
builder.Services.ConfigureRepositories();
builder.Services.ConfigureServices();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAutoMapper(typeof(OwnerProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseGlobalExceptionMiddleware();

app.UseRequestTimeMiddleware();

app.MapControllers();

app.Run();
