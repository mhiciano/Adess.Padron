using Adess.Padron.Application.Contracts;
using Adess.Padron.Application.Implementations;
using Adess.Padron.Persistance;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string defaultConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<PadronDbContext>(option => option.UseSqlServer(defaultConnection));

// Add services to the container.
builder.Services.AddScoped<IHttpClientService, HttpClientService>((serviceImplementation) => new HttpClientService(new HttpClient()));

builder.Services.AddScoped<IPadronUnitOfWork, PadronUnitOfWork>();

builder.Services.AddScoped<IPadronService, PadronService>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();



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
