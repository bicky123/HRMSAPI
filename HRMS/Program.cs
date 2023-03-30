using AutoMapper;
using FluentValidation.AspNetCore;
using HRMS._Helpers;
using HRMS.Business.Commands;
using HRMS.Business.Queries.InputQueryMapper;
using HRMS.Business.Queries.InputResultMapper;
using HRMS.Comman.ApiResponse;
using HRMS.EFDb;
using HRMS.EFDb.Domain;
using HRMS.EFDb.Extension;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ValidationFilter());
})
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            var result = new BadRequestObjectResult(new Response(400, "Invalid data types"));
            // TODO: add `using System.Net.Mime;` to resolve MediaTypeNames
            result.ContentTypes.Add(MediaTypeNames.Application.Json);
            return result;
        };
    })
    .AddFluentValidation(options =>
    {
        options.RegisterValidatorsFromAssemblyContaining<Program>();
    })
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Custom configuration

//Adding MediatR
var assembly = AppDomain.CurrentDomain.Load("HRMS.Business");
builder.Services.AddMediatR(assembly);

//Entity FrameWork Identity Setup
builder.Services.AddEfSetup(builder.Configuration);

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddEfInject();

//Automapper setup
builder.Services.AddAutoMapper(typeof(Program));
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new QueryMapperProfile());
    mc.AddProfile(new QueryResultMapperProfile());
    mc.AddProfile(new CommandMapperProfile());
});

var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


//JWT token setup
builder.Services.AddJwtSetup(builder.Configuration);

//Allow cors
builder.Services.AddCors(option =>
{
    option.AddPolicy("CorsApi",
        builder => builder.WithOrigins("http://localhost:4200", "http://mywebsite.com")
        .AllowAnyHeader()
        .AllowAnyMethod());
});

//middleware
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseGlobalExceptionHandler();

app.UseHttpsRedirection();
app.UseCors("CorsApi");

app.UseAuthentication();
app.UseAuthorization();

if (!app.Environment.IsDevelopment())
{
    app.UseAPIKeyMiddleware();
}

app.MapControllers();

app.Run();
