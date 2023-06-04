using Api.Services.Implementations;
using Api.Services.Interfaces;
using Api.Services.Store;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddResponseCaching();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrations
builder.Services.AddScoped<IEvaluationService, EvaluationService>();
builder.Services.AddScoped<IDataProvider, DataProvider>();
builder.Services.AddScoped<SchoolStore>();


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

app.UseResponseCaching(); // Please note: must be after UserCors()
app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();