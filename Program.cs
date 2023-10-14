using Npgsql;
using TaskManagement.App_Start;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ServicesConfiguration.ServicesRegister(builder);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
