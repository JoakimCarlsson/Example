using DummyApiExample.Api;
using DummyApiExample.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDummyApi(x =>
{
    x.ApiKey = builder.Configuration.GetValue<string>("DummyApi:ApiKey");
    x.BaseUrl = builder.Configuration.GetValue<string>("DummyApi:BaseUrl");
});

builder.Services.AddTransient<IDummyApiServiceHelper, DummyApiServiceHelper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
