using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UsuariosApi.Configuration;
using UsuariosApi.Data;
using UsuariosApi.Models;
using UsuariosApi.Services;
using UsuariosApi.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<UsuariosApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<CustomIdentityUser, IdentityRole<int>>()
                .AddEntityFrameworkStores<UsuariosApiContext>()
                .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequiredLength = 6;
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ICadastroService, CadastroService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.Configure<EmailSettingsConfig>(
    builder.Configuration.GetSection("EmailSettings"));

builder.Services.AddControllers();

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
