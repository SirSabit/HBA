using RatingService.Api.ExceptionHandlers;
using RatingService.Bll.Extensions;
using RatingService.Dal.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddBllServices();
builder.Services.AddSwaggerGen();

#region Exception Handling
builder.Services.AddExceptionHandler<BadRequestExceptionHandler>();
builder.Services.AddExceptionHandler<NotFoundExceptionHandler>();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
app.HandleMigration();

app.UseSwagger();
app.UseSwaggerUI();

app.UseExceptionHandler();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
