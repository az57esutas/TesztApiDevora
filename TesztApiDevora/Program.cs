using TesztApiDevora;
using TesztApiDevora.Services;

namespace TesztApiDevora
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<IArenaService, ArenaService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

           
            app.MapPost("/api/arena/randomFighterGenerate", (int numberOfHeroes, IArenaService arenaService) =>
            {
                var arenaId = arenaService.GenerateRandomFighters(numberOfHeroes);
                return Results.Ok(arenaId);
            });

            app.MapPost("/api/arena/battle", (Guid arenaId, IArenaService arenaService) =>
            {
                try
                {
                    var arena = arenaService.SimulateBattle(arenaId);
                    return Results.Ok(arena);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });

            app.Run();
        }
    }
}
