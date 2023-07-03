using DeckOfCardsLibrary;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<Deck> Decks => Set<Deck>();
        public DbSet<Card> Cards => Set<Card>();


        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
    }
}