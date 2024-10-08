using CustomersManagement.Api.Middleware;
using CustomersManagement.Api.Models;
using CustomersManagement.Application;
using CustomersManagement.Application.Models.Identity;
using CustomersManagement.Identity;
using CustomersManagement.Infrastructure;
using CustomersManagement.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("all", builder => builder.AllowAnyOrigin()
                                            .AllowAnyHeader()
                                            .AllowAnyMethod());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(Policies.TravelAgency, policy =>
         policy.RequireRole(RoleName.Administrator, RoleName.TravelAgencyEmployee));
    options.AddPolicy(Policies.DivingSchool, policy =>
         policy.RequireRole(RoleName.Administrator, RoleName.DivingSchoolEmployee));
});

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("all");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
