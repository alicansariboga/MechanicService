using MechanicService.Application.Interfaces.CarModelnterfaces;
using MechanicService.Application.Interfaces.ReservationInterfaces;
using MechanicService.Persistence.Repositories.CarModelRepositories;
using MechanicService.Persistence.Repositories.ReservationRepositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

// Add services to the container.

#region Registrations
builder.Services.AddScoped<MechanicServiceContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(ILocationsRepository), typeof(LocationsRepository));
builder.Services.AddScoped(typeof(ICarModelRepository), typeof(CarModelRepository));
builder.Services.AddScoped(typeof(IReservationRepository), typeof(ReservationRepository));
#endregion

// ServiceRegistration
builder.Services.AddApplicationService(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS Configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("https://localhost:7170") // Ýzin verilecek origin'leri buraya ekleyin
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// CORS Middleware
app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
