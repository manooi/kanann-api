using System.Net;
using System.Security.Claims;
using App;
using App.Service;
using App.Service.Authorization;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using AutoWrapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IMasterRepository, MasterRepository>();
builder.Services.AddScoped<ITransactionClassRepository, TransactionClassRepository>();
builder.Services.AddScoped<IRFIDRepository, RFIDRepository>();
builder.Services.AddScoped<IAssignmentRepository, AssignmentRepository>();
builder.Services.AddDbContext<KananContext>(opt =>
{
    opt.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), serverVersion)
        .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name },
            Microsoft.Extensions.Logging.LogLevel.Information);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowOrigin",
        builder =>
        {
            builder.WithOrigins("https://dev.xn--42c6ba4gwd.com")
                .AllowAnyHeader()
                .AllowAnyMethod();

            builder.WithOrigins("https://xn--42c6ba4gwd.com")
                .AllowAnyHeader()
                .AllowAnyMethod();

            builder.WithOrigins("https://kanann-webapp.pages.dev")
                .AllowAnyHeader()
                .AllowAnyMethod();

            builder.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});


#region Auth0 services

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.Authority = "";
        options.Audience = "";
    });

#endregion

#region Auth0 role services

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("admin",
        policy => policy.Requirements.Add(new HasScopeRequirement("admin")));

    options.AddPolicy("teacher",
        policy => policy.Requirements.Add(new HasScopeRequirement("teacher")));

    options.AddPolicy("student",
        policy => policy.Requirements.Add(new HasScopeRequirement("student")));

    options.AddPolicy("all users",
        policy => policy.Requirements.Add(new HasScopeRequirement("admin teacher student")));
});

builder.Services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();

#endregion

var app = builder.Build();
app.Urls.Add("http://localhost:5000");
app.UseApiResponseAndExceptionWrapper();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseCors("AllowOrigin");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();