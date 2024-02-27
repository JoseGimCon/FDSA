using Aplication.IOC;
using Infrastucture.Extensions;
using Microsoft.OpenApi.Models;
using moonhotelsapi.extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
});

builder.Services.AddApplicationLayer();
builder.Services.AddapiVersioningExtension();
builder.Services.AddInfrasturtureExtension();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();

