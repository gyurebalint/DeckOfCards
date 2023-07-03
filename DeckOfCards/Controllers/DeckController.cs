using Microsoft.AspNetCore.Mvc;
using DeckOfCardsLibrary;
using Data;
using Microsoft.EntityFrameworkCore;

namespace DeckOfCards.Controllers;

[ApiController]
[Route("[controller]")]
public class DeckController : ControllerBase
{

    private readonly ILogger<DeckController> _logger;
    private readonly AppDbContext _dbContext;

    public DeckController(ILogger<DeckController> logger, AppDbContext dbContext)
    {
        _logger = logger;
        this._dbContext = dbContext;
    }

    [HttpGet]
    [Route("new")]
    public async Task<IResult> Get()
    {
        Deck deck = new Deck(52);
        var item = await _dbContext.Decks.AddAsync(deck);

        if(item.State == EntityState.Added)
        {
            await _dbContext.SaveChangesAsync();
            return Results.Created($"deck/new/{deck.DeckId}", deck);
        }
        return Results.NotFound(item.Entity);
    }

    [HttpGet]
    [Route("decks")]
    public async Task<IActionResult> GetAll()
    {
        var allDecks = await _dbContext.Decks
            .Include(d => d.Cards)
            .ToListAsync();

        return Ok(allDecks);
    }


    [HttpGet]
    [Route("shuffle/{deckId}")]
    public async Task<IActionResult> Get(int deckId)
    {
        var deck = await _dbContext.Decks
        .Include(d=>d.Cards)
        .FirstOrDefaultAsync(c=>c.DeckId == deckId);

        if (deck is null)
        {
            return NotFound();
        }
        deck.Shuffle();
        
        return Ok(deck);
    }
}
