using Api.Services.Implementations;
using Api.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrations
builder.Services.AddScoped<IEvaluationService, EvaluationService>();
builder.Services.AddScoped<IDataProvider, DataProvider>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("default", policy =>
    {
        policy.WithOrigins("http://localhost:5173/", "https://hackcodex-fe-b26y.vercel.app/")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

//

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("default");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
