using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NetPostgresProjet.DAL.Data;

var builder = WebApplication.CreateBuilder(args);

// 🔥 Ajoute cette ligne :
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy => policy.WithOrigins("http://localhost:4200")  // a modifier 
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Configure Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "NetPostgresProjet API", Version = "v1" });
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

// Database Context
builder.Services.AddDbContext<HospitalDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") // <- ton app Angular
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "NetPostgresProjet API v1");
    });
}

app.UseCors("AllowFrontend");
// 🔥 Et active ici :
app.UseCors("AllowAngular");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();