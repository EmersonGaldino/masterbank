
using master.bank.api.configuration.autoMapper;
using master.bank.bootstrapper.configurations.auth;
using master.bank.bootstrapper.configurations.autoMapper;
using master.bank.bootstrapper.configurations.cors;
using master.bank.bootstrapper.configurations.dependencyInjection;
using master.bank.bootstrapper.configurations.logger;
using master.bank.bootstrapper.configurations.security;
using master.bank.bootstrapper.configurations.swagger;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

// Add services to the container.
builder.Host.UseSerilog();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//My injections
services.AddAutoMapperConfiguration();
services.AddAutoMapperModelViewConfiguration();

AuthConfiguration.Register(services, configuration);
LoggerBuilder.ConfigureLogging();

services.AddProtectedControllers();
services.AddServices(configuration); // Injetar servicos
services.AddCors();
services.AddSwaggerService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCorsConfig();
app.UseAuthorization();
app.UseAuthentication();
app.UseRouting();
app.UseSwaggerConfig();
app.UseEndpointsConfig();

app.Run();

