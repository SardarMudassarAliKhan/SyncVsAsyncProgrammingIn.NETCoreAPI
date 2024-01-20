using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SyncVsAsyncProgrammingIn.NETCoreAPI.ApplicationDbContext;
using SyncVsAsyncProgrammingIn.NETCoreAPI.IRepository;
using SyncVsAsyncProgrammingIn.NETCoreAPI.Repository;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")); // Replace with your database provider and connection string
});
// Add services to the container.
builder.Services.AddTransient<IUserRepository , UserRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sync Vs Async Programming In Asp.Net Core Web API", Version = "v1" });

});
var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
