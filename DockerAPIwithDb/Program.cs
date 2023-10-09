using DockerAPIwithDb;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(opt =>
    opt.UseNpgsql("host=postgres_image;port=5432;database=testing;username=postgres;password=postgres")
);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MapGet("/test", (context) =>
{
    return context.Response.WriteAsync("12312");
});

app.MapControllers();

app.UseAuthorization();




app.Run();