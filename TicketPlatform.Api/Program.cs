using TicketPlatform.Core.Interfaces;
using TicketPlatform.Core.Services;
using TicketPlatform.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
 
// Inyeccion de Dependencias (Repositorios y Servicios)

builder.Services.AddTransient<IAssignmentsRepository, AssignmentsRepository>();
builder.Services.AddTransient<IAssignmentService, AssigmentService>();
builder.Services.AddTransient<IStatusService, StatusService>();
builder.Services.AddTransient<IStatusRepository, StatusRepository>();
builder.Services.AddTransient<ITicketRespository, TicketRepository>();
builder.Services.AddTransient<ITicketService, TicketService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

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

app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();
