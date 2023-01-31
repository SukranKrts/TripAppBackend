using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TripApplication.Data;
using TripApplication.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<MainDb>(builder =>
{
    builder.UseSqlServer(" Server = DESKTOP-C4B27HE; Database = trip.db; Trusted_Connection = True;trustServerCertificate=true;");
    builder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
builder.Services.AddScoped<CompanyService>();
builder.Services.AddScoped<TripService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<PaymentService>();
builder.Services.AddScoped<TripCommentsService>();
builder.Services.AddScoped<FollowService>();
builder.Services.AddScoped<CompanyPointService>();
builder.Services.AddScoped<BasketService>();
builder.Services.AddScoped<FavouriteService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        b => b
        .AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed(origin => true)
        .AllowCredentials()
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
