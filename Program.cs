using BooksAPI;
using BooksAPI.Filters;
using BooksAPI.Helpers;
using BooksAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
var fronendURL = builder.Configuration.GetValue<string>("frontendURL");
var DBConnetion = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(ExceptionFilters));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//DBConnection
builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseSqlServer(DBConnetion); 
});
//CORS for Frontend Use.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(Builder =>
    {
        Builder.WithOrigins(fronendURL).AllowAnyMethod().AllowAnyHeader();
    });
});

//AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
//Autentification JWT.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme ).AddJwtBearer();   
builder.Services.AddResponseCaching();

var app = builder.Build();
var env = app.Environment;
// Configure the HTTP request pipeline.
if (env.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors();

app.UseAuthentication();  

app.UseAuthorization();

app.MapControllers();

app.Run(/*async context =>
{
    await context.Response.WriteAsync("I'm a short-circuiting the pipeline");
}*/);


