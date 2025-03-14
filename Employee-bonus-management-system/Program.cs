using EmployeeBonusManagement.Application.Services;
using EmployeeBonusManagement.Application.Interfaces;
using EmployeeBonusManagement.Core.Entities;
using EmployeeBonusManagement.Infrastructure.Data;
using EmployeeBonusManagement.Infrastructure.Repositories;
using EmployeeBonusManagement.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AuthDbContext>(options =>
	options.UseSqlServer(connectionString));

//Register Identity
builder.Services.AddIdentity<ApplicationUser, ApplicationRoles>()
	.AddEntityFrameworkStores<AuthDbContext>()
	.AddDefaultTokenProviders();

builder.Services.AddScoped(typeof(IEmployeeRepository<>), typeof(EmployeeRepository<>));

builder.Services.AddScoped<IEmployeeService, ManageEmployeesService>();

//Register Authorization & Authentication
builder.Services.AddAuthorization();
builder.Services.AddSingleton<IEmailSender, Microsoft.AspNetCore.Identity.UI.Services.NoOpEmailSender>();

//  Register RoleSeeder 
builder.Services.AddScoped<RoleSeederService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware & Routing
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
	var roleSeeder = scope.ServiceProvider.GetRequiredService<RoleSeederService>();
	await roleSeeder.SeedRolesAsync();
}

app.Run();
