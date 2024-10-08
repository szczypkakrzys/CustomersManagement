using Blazored.LocalStorage;
using CustomersManagement.UI;
using CustomersManagement.UI.Contracts;
using CustomersManagement.UI.Models;
using CustomersManagement.UI.Providers;
using CustomersManagement.UI.Services;
using CustomersManagement.UI.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Reflection;
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri("https://localhost:7193"));

builder.Services.AddAntDesign();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore(options =>
{
    options.AddPolicy(Policies.TravelAgency, policy =>
         policy.RequireRole(Roles.Administrator, Roles.TravelAgencyEmployee));
    options.AddPolicy(Policies.DivingSchool, policy =>
         policy.RequireRole(Roles.Administrator, Roles.DivingSchoolEmployee));
});
builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
builder.Services.AddScoped<ITravelAgencyCustomerService, TravelAgencyCustomerService>();
builder.Services.AddScoped<ITourService, TourService>();
builder.Services.AddScoped<IDivingSchoolCustomerService, DivingSchoolCustomerService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICustomNotificationService, CustomNotificationService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

await builder.Build().RunAsync();