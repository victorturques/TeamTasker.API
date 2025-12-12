using TeamTasker.API.Extensions;
using TeamTasker.API.Repositories; 

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()  // Aceita requisição de qualquer site (localhost:3000, etc)
              .AllowAnyMethod()  // Aceita GET, POST, PUT, DELETE
              .AllowAnyHeader(); // Aceita qualquer cabeçalho (tokens, etc)
    });
});


builder.Services.ConfigureDatabase(builder.Configuration);

builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();



var app = builder.Build();

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAll");

app.MapGet("/", () => Results.Redirect("/swagger"));

app.UseAuthorization();

app.MapControllers();

app.Run();