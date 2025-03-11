using EmployeeBonusManagement.Application.Services;
using EmployeeBonusManagement.Application.Interfaces;
using EmployeeBonusManagement.Core.Entities;
using EmployeeBonusManagement.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services; 

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register DbContext
builder.Services.AddDbContext<AuthDbContext>(options =>
	options.UseSqlServer(connectionString));

// Register Identity services with your custom ApplicationUser
builder.Services.AddIdentity<ApplicationUser, ApplicationRoles>()
	.AddEntityFrameworkStores<AuthDbContext>()
	.AddDefaultTokenProviders(); // Token providers like for password resets, etc.

builder.Services.AddAuthorization();

// Register a dummy IEmailSender (No-Operation Email Sender)
builder.Services.AddSingleton<IEmailSender, Microsoft.AspNetCore.Identity.UI.Services.NoOpEmailSender>();  // Ensure NoOpEmailSender is correctly referenced

builder.Services.AddScoped<RoleSeederService>();
// Add controllers and Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Map Identity API endpoints (if exposing Identity API)
//app.MapIdentityApi<ApplicationUser>();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
	var roleSeeder = scope.ServiceProvider.GetRequiredService<RoleSeederService>();
	await roleSeeder.SeedRolesAsync();
}

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
