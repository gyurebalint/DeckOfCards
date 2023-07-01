
namespace DeckOfCardsLibrary
{
    public class Table
    {
        public int Id { get; set; }
        public Deck Deck { get; }
        public List<Player> Players { get; }
        public List<Card> Flop { get; } = new List<Card>();
        public int SmallBlind{ get; set; }
        public int LargeBlind { get; set; }


        public Table(Deck deck, List<Player> players, int smallBlind, int largeBlind)
        {
            Deck = deck;
            Players = players;
            SmallBlind = smallBlind;
            LargeBlind = largeBlind;
        }

    }
}
