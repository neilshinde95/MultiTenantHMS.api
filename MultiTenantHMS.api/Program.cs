using MultiTenantHMS.BLL.Interfaces;
using MultiTenantHMS.BLL.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowConfiguredOrigins", policy =>
    {
        if (allowedOrigins != null && allowedOrigins.Length > 0)
        {
            policy.WithOrigins(allowedOrigins)
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        }
        else
        {
            // fallback for local dev if nothing found
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        }
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "MultiTenantHMS.api", Version = "v1" });
});

// ✅ STEP 1: Add CORS service
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy
            .WithOrigins("http://localhost:51295") // Angular app origin
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});



// Register the PatientService and its interface for dependency injection.
builder.Services.AddScoped<ICommonService, CommonService>();

var app = builder.Build();

// ✅ STEP 2: Use CORS BEFORE authorization or routing
app.UseCors("AllowAngularApp");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MultiTenantHMS.api v1"));
}

app.UseCors("AllowConfiguredOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
