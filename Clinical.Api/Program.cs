using Clinical.Api.Services.Implementations;
using Clinical.Api.Services.Interfaces;
using Clinical.Infra.Data.Context;
using Clinical.Infra.IOC.DependencyContainer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Config Database

builder.Services.AddDbContext<ClinicalContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ClinicalConnectionString"));
});

#endregion

//builder.Services.AddCors(opt => opt.AddPolicy("velPolicy", policy =>
//{
//    policy.AllowAnyMethod()
//    .AllowAnyMethod()
//    .WithOrigins("http//localhost:3000");
//}));
#region Register Services
builder.Services.RegisterServices();
builder.Services.AddScoped<ITokenService, TokenService>();
#endregion

#region Config Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]));
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = key,
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseCors("velPolicy");

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
