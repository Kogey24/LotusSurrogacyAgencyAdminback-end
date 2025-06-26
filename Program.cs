using System.Text;
using AutoMapper;
using Lotus_surrogacy_agency_Admin_panel.Container;
using Lotus_surrogacy_agency_Admin_panel.Modal;
using Lotus_surrogacy_agency_Admin_panel.Modal.Helper;
using Lotus_surrogacy_agency_Admin_panel.Models;
using Lotus_surrogacy_agency_Admin_panel.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionstring = builder.Configuration.GetConnectionString("constring");
builder.Services.AddDbContext<LotusFertilitySurrogacyContext>(o => o.UseMySql(connectionstring, ServerVersion.AutoDetect(connectionstring)));
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IClientService, ClientService>();
builder.Services.AddTransient<IUserRoleService, UserRoleService>();
builder.Services.AddTransient<IRefreshHandler, RefreshHandler>();

//builder.Services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
var _jwtsettings = builder.Configuration.GetSection("JwtSettings");
builder.Services.Configure<JWTSettings>(_jwtsettings);

var _authkey = builder.Configuration.GetValue<string>("JwtSettings:securitykey");
builder.Services.AddAuthentication(item =>
{
    item.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    item.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(item =>
{
    item.RequireHttpsMetadata = true;
    item.SaveToken = true;
    item.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authkey)),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});

var automapper = new MapperConfiguration(item => item.AddProfile(new AutoMapperHandler()));
IMapper mapper = automapper.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddCors(p => p.AddDefaultPolicy(build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
