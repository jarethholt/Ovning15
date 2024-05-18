using Tournament.Data.Data;

namespace Tournament.Api.Extensions;

public static class ApplicationBuilderExtensions
{
    public static async Task<IApplicationBuilder> SeedDataAsync(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<TournamentContext>();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        List<Core.Entities.Tournament> tournaments = [
            new() { Title = "2023 World Women's Handball Championship", StartDate = new(2023, 11, 29, 18, 00, 00), Games = [
                new() { Title = "Quarterfinals 2-1 (France) vs 4-2 (Czech Republic)", Time = new DateTime(2023, 12, 12, 17, 30, 00) },
                new() { Title = "Quarterfinals 4-1 (Netherlands) vs 2-2 (Norway)", Time = new DateTime(2023, 12, 12, 20, 30, 00) },
                new() { Title = "Quarterfinals 1-1 (Sweden) vs 3-2 (Germany)", Time = new DateTime(2023, 12, 13, 17, 30, 00) },
                new() { Title = "Quarterfinals 3-1 (Denmark) vs 1-2 (Montenegro)", Time = new DateTime(2023, 12, 13, 20, 30, 00) }
            ] },
        ];
        context.AddRange(tournaments);
        await context.SaveChangesAsync();
        return app;
    }
}