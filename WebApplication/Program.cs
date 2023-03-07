using DemoEF.DBContext;
using DemoEF.middlewares;
using DemoEF.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ApplicationDbContext>( options
    => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection")));
builder.Services.AddSwaggerGen();

// builder.Services.AddTransient<ServiceA>();
// builder.Services.AddScoped<IService, ServiceA>();
// builder.Services.AddSingleton<IService, ServiceA>();
builder.Services.AddTransient<IService, ServiceA>();
builder.Services.AddTransient<ServiceTransient>();
builder.Services.AddScoped<ServiceScoped>();
builder.Services.AddSingleton<ServiceSingleton>();


builder.Services.AddResponseCaching();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();

var app = builder.Build();

// Configure the HTTP request pipeline.

/* Add an example to Middlerware */

// First option - to catch output messages 
//app.Use(async (contexto, siguiente) =>
//{
//    using(var ms = new MemoryStream())
//    {
//        var cuerpoOriginalRespuesta = contexto.Response.Body;
//        contexto.Response.Body = ms;

//        await siguiente.Invoke();

//        ms.Seek(0, SeekOrigin.Begin);
//        string respuesta = new StreamReader(ms).ReadToEnd();
//        ms.Seek(0, SeekOrigin.Begin);

//        await ms.CopyToAsync(cuerpoOriginalRespuesta);
//        contexto.Response.Body = cuerpoOriginalRespuesta;

//        app.Logger.LogInformation(respuesta);

//    }
//});


// Seconf option - to catch output messages with a class
// app.UseMiddleware<LoguearRespuestaHTTPMiddleware>();


// Third option creating a static class to catch output messages
app.UseLoguearRespuestaHTTP();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseResponseCaching();

app.UseAuthorization();

app.MapControllers();

app.Run();
