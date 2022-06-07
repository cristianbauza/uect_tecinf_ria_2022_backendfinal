using Microsoft.EntityFrameworkCore;
using DataAccessLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.OpenApi.Models;
using DataAccessLayer.DALs.Interfaces;
using DataAccessLayer.DALs.Implementations;
using BusinessLayer.Interfaces;
using BusinessLayer.Implementations;
using RIA2022;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// For Entity Framework
builder.Services.AddDbContext<DataContext>(options => options.UseMySql(configuration["ConnectionStrings:WebApiDatabase"],
    ServerVersion.AutoDetect(configuration["ConnectionStrings:WebApiDatabase"])));

// For Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<DataContext>()
    .AddDefaultTokenProviders();

// Adding Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

// Adding Jwt Bearer
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        //ValidAudience = configuration["JWT:ValidAudience"],
        //ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
    };
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."        
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
        {
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    },
        new string[] {}
    }});
});

// Agregamos las inyecciones de dependencia.
builder.Services.AddTransient<IDAL_Noticias, DAL_Noticias_EF>();
builder.Services.AddTransient<IDAL_Documentos, DAL_Documentos_EF>();


builder.Services.AddTransient<IBL_Noticias, BL_Noticias>();
builder.Services.AddTransient<IBL_Documentos, BL_Documentos>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Make sure you call this before calling app.UseMvc()
app.UseCors(
    options => options.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader()
);

app.UseAuthentication();
app.UseAuthorization();

StartUp.UpdateDatabase(app);

app.MapControllers();

app.Run();

