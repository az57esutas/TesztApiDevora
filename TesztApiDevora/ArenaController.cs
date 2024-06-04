using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OpenApi;
using TesztApiDevora.Classes;
using TesztApiDevora.Services;
namespace TesztApiDevora;

[ApiController]
[Route("api/[controller]")]
public class ArenaController : ControllerBase
{
    private readonly IArenaService _arenaService;

    public ArenaController(IArenaService arenaService)
    {
        _arenaService = arenaService;
    }

    [HttpPost("randomFighterGenerator")]
    public ActionResult<Guid> GenerateRandomHeroes([FromBody] int numberOfHeroes)
    {
        var arenaId = _arenaService.GenerateRandomFighters(numberOfHeroes);
        return Ok(arenaId);
    }

    [HttpPost("battle")]
    public ActionResult<Arena> SimulateBattle([FromBody] Guid arenaId)
    {
        try
        {
            var arena = _arenaService.SimulateBattle(arenaId);
            return Ok(arena);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
