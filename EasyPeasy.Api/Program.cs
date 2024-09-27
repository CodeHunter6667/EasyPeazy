using EasyPeasy.Api.Common.Api;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfigurations();
builder.AddDataContext();
builder.AddAutoMapper();
builder.AddServices();
builder.AddDocumentation();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    app.ConfigureDevEnvironment();

app.ConfigureExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();