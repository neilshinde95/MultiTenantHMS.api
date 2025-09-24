using MultiTenantHMS.BLL.Interfaces;
using MultiTenantHMS.BLL.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "MultiTenantHMS.api", Version = "v1" });
});


// Register the PatientService and its interface for dependency injection.
builder.Services.AddScoped<ICommonService, CommonService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MultiTenantHMS.api v1"));
}

app.UseAuthorization();

app.MapControllers();

app.Run();
