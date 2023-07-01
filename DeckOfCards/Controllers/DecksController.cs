using DeckOfCardsLibrary;
using Microsoft.AspNetCore.Mvc;

namespace DeckOfCards.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DecksController : ControllerBase
    {
        [HttpGet("{id}")]
        public Deck Get(int id)
        {
            return new Deck();
        }

        [HttpGet]
        public IEnumerable<Deck> GetDecks()
        {
            return Enumerable.Empty<Deck>();
        }

        [HttpGet("new")]
        public Deck Create()
        {
            return new Deck { Id = 1 };
        }

        //[HttpGet("{id}")]
        //public Deck Shuffle()
        //{  
        //    throw new NotImplementedException(); 
        //}
    }
}