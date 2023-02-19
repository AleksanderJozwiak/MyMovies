using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using MojeFilmy;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddCors();

builder.Services.AddDbContext<MovieContext>(
    option => option.UseSqlite(builder.Configuration.GetConnectionString("MoviesDb"))
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapGet("data", async (MovieContext db) => 
{
    var movies = await db.Movies.ToListAsync();
    return movies;
});

app.MapPost("create", async (MovieContext db, Movie movie) => 
{
    await db.Movies.AddAsync(movie);
    await db.SaveChangesAsync();
});

app.MapPut("update", async (MovieContext db, Movie movie) => 
{ 
    Movie m = await db.Movies.FirstAsync(m => m.id == movie.id);

    m.title= movie.title;
    m.director= movie.director;
    m.year= movie.year;
    m.rate= movie.rate;

    await db.SaveChangesAsync();
});

app.MapDelete("delete", async(MovieContext db, int id) =>
{
    var movies = await db.Movies.Where(m => m.id==id).ToListAsync();
    db.Movies.RemoveRange(movies);

    await db.SaveChangesAsync();
});

app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.Run();
