var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

// Add services to the container.

#region Registrations
builder.Services.AddScoped<MechanicServiceContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
#endregion

// ServiceRegistration
builder.Services.AddApplicationService(builder.Configuration);

builder.Services.AddControllers();
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
