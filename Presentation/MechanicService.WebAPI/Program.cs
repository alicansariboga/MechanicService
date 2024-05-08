using MechanicService.Application.Interfaces.AppUserInterfaces;
using MechanicService.Application.Interfaces.BlogInterfaces;
using MechanicService.Application.Interfaces.CustomerInterfaces;
using MechanicService.Application.Interfaces.TagInterfaces;
using MechanicService.Application.Tools;
using MechanicService.Persistence.Repositories.AppUserRepositories;
using MechanicService.Persistence.Repositories.BlogRepositories;
using MechanicService.Persistence.Repositories.CustomerRepositories;
using MechanicService.Persistence.Repositories.TagRepositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

// Add services to the container.

// CORS Configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("https://localhost:7170") // allowed origin
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

//builder.Services.AddCors(opt =>
//{
//    opt.AddPolicy("CorsPolicy", builder =>
//    {
//        builder.AllowAnyHeader()
//        .AllowAnyMethod()
//        .SetIsOriginAllowed((host) => true)
//        .AllowCredentials();
//    });
//});


//Json Web Token(JWT)
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidAudience = JwtTokenDefaults.ValidAudience,
        ValidIssuer = JwtTokenDefaults.ValidIssuer,
        ClockSkew = TimeSpan.Zero, // start time
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key)),
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});

#region Registrations
builder.Services.AddScoped<MechanicServiceContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(ILocationsRepository), typeof(LocationsRepository));
builder.Services.AddScoped(typeof(ICarModelRepository), typeof(CarModelRepository));
builder.Services.AddScoped(typeof(IReservationRepository), typeof(ReservationRepository));
builder.Services.AddScoped(typeof(IStatisticsRepository), typeof(StatisticsRepository));
builder.Services.AddScoped(typeof(ICustomerRepository), typeof(CustomerRepository));
builder.Services.AddScoped(typeof(IAppUserRepository), typeof(AppUserRepository));
builder.Services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
builder.Services.AddScoped(typeof(ITagRepository), typeof(TagRepository));
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

// CORS Middleware
app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
