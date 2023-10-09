using EAD_BACKEND.Implementations;
using EAD_BACKEND.Interfaces;
using EAD_BACKEND.IServices;
using EAD_BACKEND.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<UserDBSettings>(builder.Configuration.GetSection(nameof(UserDBSettings)));

builder.Services.AddSingleton<IUserDBSettings>(sp => sp.GetRequiredService<IOptions<UserDBSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("UserDBSettings:ConnectionString")));

builder.Services.AddScoped<IUserService, UserService>();


builder.Services.Configure<TrainDBSettings>(builder.Configuration.GetSection(nameof(TrainDBSettings)));

builder.Services.AddSingleton<ITrainDBSettings>(sp => sp.GetRequiredService<IOptions<TrainDBSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("TrainDBSettings:ConnectionString")));

builder.Services.AddScoped<ITrainService, TrainService>();

builder.Services.Configure<TicketDBSettings>(builder.Configuration.GetSection(nameof(TicketDBSettings)));

builder.Services.AddSingleton<ITicketDBSettings>(sp => sp.GetRequiredService<IOptions<TicketDBSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("TicketDBSettings:ConnectionString")));

builder.Services.AddScoped<ITicketService, TicketService>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});






var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowAnyOrigin");

app.MapControllers();

app.Run();
