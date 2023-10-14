using DockerAPIwithDb;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


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

// public static class EnsureMigration
// {
//     public static void EnsureMigrationOfContext<T>(this IApplicationBuilder app) where T:DbContext
//     {
//         var context = app.ApplicationServices.GetService<T>();
//         context.Database.Migrate();
//         context.Database.EnsureCreated();
//     }
// }