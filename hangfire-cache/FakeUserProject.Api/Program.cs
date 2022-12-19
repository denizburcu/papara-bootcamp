using FakeUserProject.Data.Context;
using FakeUserProject.Data.Contract;
using FakeUserProject.Data.Repository;
using FakeUserProject.Data.Models;
using FakeUserProject.Infrastructure.Concrete;
using FakeUserProject.Infrastructure.Contract;
using FakeUserProject.Service.Concrete;
using FakeUserProject.Service.Contract;
using FakeUserProject.Service.Profiles;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using FakeUserProject.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    options => options.MigrationsAssembly("FakeUserProject.Api"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRecurringUserFakeJob, RecurringUserFakeJob>();
builder.Services.AddScoped<IMemCacheService, MemCacheService>();
builder.Services.AddAutoMapper(typeof(UserProfile));
builder.Services.AddScoped<IRepository<User>, Repository<User>>();

builder.Services.AddMemoryCache();
builder.Services.AddHangfire(x =>
    {
        x.UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection"));
    });
builder.Services.AddHangfireServer();

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
