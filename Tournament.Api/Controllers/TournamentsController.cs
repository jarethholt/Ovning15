using Tournament.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Tournament.Api.Controllers;

[ApiController]
[Route("api/tournaments")]
public class TournamentsController : ControllerBase
{
    private readonly TournamentContext _context;

    public TournamentsController(TournamentContext context) =>
        _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Core.Entities.Tournament>>> GetTournamentsAsync()
    {
        var tournaments = await _context.Tournament.ToListAsync();
        return Ok(tournaments);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Core.Entities.Tournament>> GetTournamentByIdAsync(int id)
    {
        var tournament = await _context.Tournament.FirstOrDefaultAsync(
            t => t.Id == id);
        
        if (tournament is null)
            return NotFound();
        return Ok(tournament);
    }

    [HttpPost]
    public async Task<ActionResult<Core.Entities.Tournament>> CreateTournament(Core.Entities.Tournament tournament)
    {
        _context.Add(tournament);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetTournamentByIdAsync), new { id = tournament.Id }, tournament);
    }
}
