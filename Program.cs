using Microsoft.EntityFrameworkCore;
using MyAplication;
using MyAplication.Operation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<PersonaOperation>();
builder.Services.AddScoped<ExerciseOperation>();
builder.Services.AddScoped<BillOperation>();

builder.Services.AddDbContext<NewDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("cadenaSQL"))
);

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
