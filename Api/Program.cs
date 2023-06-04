using Api.Services.Implementations;
using Api.Services.Interfaces;
using Api.Services.Store;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.FileProviders;
using System.ComponentModel.DataAnnotations;

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
builder.Services.AddScoped<DataStore>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("default", policy =>
    {
        policy.WithOrigins("https://localhost:5173", "http://localhost:5173/", "https://hackcodex-fe-b26y.vercel.app/")
            .AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod();
    });
});

//

var app = builder.Build();



app.UseExceptionHandler(app =>
{
    app.Run(async context =>
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = "text/plain";

        var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
        if (exceptionHandlerFeature?.Error != null)
        {
            string errorMessage = "An unexpected error occurred.";

            // Customize the error message based on the exception type if needed
            if (exceptionHandlerFeature.Error is ValidationException)
            {
                errorMessage = $"A specific error occurred. {exceptionHandlerFeature.Error.Message}";
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
            }

            await context.Response.WriteAsync(errorMessage);
        }
    });
});


// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("default");

app.UseResponseCaching(); // Please note: must be after UserCors()
app.UseHttpsRedirection();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "Data")),
    RequestPath = "/static"
});

app.UseAuthorization();
app.MapControllers();

app.Run();