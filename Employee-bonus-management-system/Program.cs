using EmployeeBonusManagement.Application.Services;
using EmployeeBonusManagement.Core.Entities;
using EmployeeBonusManagement.Infrastructure.Data;
using EmployeeBonusManagement.Infrastructure.Repositories;
using EmployeeBonusManagement.Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EmployeeBonusManagement.Application.Services.Interfaces;
using EmployeeBonusManagement.Application.DTOs;
using IEmailSender = EmployeeBonusManagement.Core.Interfaces.IEmailSender;
using NoOpEmailSender = EmployeeBonusManagement.Application.Services.NoOpEmailSender;
using Microsoft.Data.SqlClient;
using System.Data;
using EmployeeBonusManagement.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);



var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AuthDbContext>(options =>
	options.UseSqlServer(connectionString));

builder.Services.AddScoped<IDbConnection>(sp => new SqlConnection(connectionString));

builder.Services.AddScoped(typeof(IEmployeeManagementRepository<>), typeof(EmployeeManagementRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped(typeof(IEmployeeRepository<>), typeof(EmployeeRepository<>));
builder.Services.AddScoped<IEmployeeService<EmployeeDto>, ManageEmployeesService>();

//Register Identity
builder.Services.AddIdentity<ApplicationUser, ApplicationRoles>()
	.AddEntityFrameworkStores<AuthDbContext>()
	.AddDefaultTokenProviders();


//Register Authorization & Authentication
builder.Services.AddAuthorization();
builder.Services.AddSingleton<IEmailSender, NoOpEmailSender>();

//  Register RoleSeeder 
builder.Services.AddScoped<RoleSeederService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(options =>
	{
		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = true,
			ValidateAudience = true,
			ValidateLifetime = true,
			ValidateIssuerSigningKey = true,
			ValidIssuer = builder.Configuration["Jwt:Issuer"], 
			ValidAudience = builder.Configuration["Jwt:Audience"], 
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
		};
	});


builder.Services.AddAuthorization(options =>
{
	options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
	options.AddPolicy("Employee", policy => policy.RequireRole("Employee"));
});



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
