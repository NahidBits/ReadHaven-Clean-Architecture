using ReadHaven.Api.Extensions;
using ReadHaven.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
        });
});

var app = builder.ConfigureServices();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // await app.ResetDatabaseAsync();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();

app.UseCustomExceptionHandler();

app.UseCors("Open");

app.MapControllers();

app.Run();
