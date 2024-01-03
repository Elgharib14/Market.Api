using Backery.DataBase;
using Backery.DataBase.Entity;
using Backery.Interface;
using Backery.Mapper;
using Backery.Modell;
using Backery.Reposatory;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var ConectionString = builder.Configuration.GetConnectionString("DefultConnection");
builder.Services.AddDbContext<AppDbContext>(
    option => option.UseSqlServer(ConectionString)
    );

builder.Services.AddScoped<ICategory, CategoryRep>();
builder.Services.AddScoped<IProduct, ProductRep>();
builder.Services.AddScoped<IStore, StoreRep>();
builder.Services.AddScoped<ISale, SaleRep>();
builder.Services.AddScoped<IAuthentication, AuthenticationRep > ();


builder.Services.Configure<JWT>( builder.Configuration.GetSection("JWT"));

builder.Services.AddAutoMapper(x => x.AddProfile(new DemoProfile()));
builder.Services.AddIdentity<AppUser,IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddAuthentication(Options =>
{
    Options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    Options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.RequireHttpsMetadata = false;
    o.SaveToken = false;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());


app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
