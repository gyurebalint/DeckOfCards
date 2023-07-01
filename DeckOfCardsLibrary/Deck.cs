
using System.Runtime.CompilerServices;

namespace DeckOfCardsLibrary
{
    public interface IDeckOfCards
    {
        public void Add(int value, Suit suit);
        public void AddMultiple(List<Card> setOfCards);

        public Card DrawRandom();
        public Card DrawFromTop();
        public void Shuffle();
    }

    public class Deck : IDeckOfCards
    {
        //At first we create a concrete poker deck then we generalize
        Random Rand = new Random();
        public int Id { get; set; }
        public int Size { get; }

        private int numberOfCardsPerSuit;
        public List<Card> Cards { get; set; }
        public Deck(int size = 52)
        {
            Cards = new List<Card>();
            var suits = Enum.GetValues<Suit>();
            numberOfCardsPerSuit = size / 4;

            foreach (Suit suit in suits)
            {
                for (int i = 1; i <= numberOfCardsPerSuit; i++)
                {
                    this.Add(i, suit);
                    Size++;
                }
            }
        }

        public Card DrawRandom(int numberOfTimes)
        {
            var index = Rand.Next(1, Cards.Count);

            var drawnCard = Cards[index];
            Cards.RemoveAt(index);

            return drawnCard;
        }

        public Card DrawFromTop(int numberOfTimes)
        {
            var topIndex = Cards.Count - 1;
            var topCard = Cards[topIndex];
            Cards.RemoveAt(topIndex);

            return topCard;
        }
    }

    public static class DeckExtensions 
    {
        public static Deck Shuffle(this Deck deck)
        {
            Random rand = new Random();
            for (int i = 0; i < deck.Cards.Count; i++)
            {
                var j = rand.Next(0, deck.Cards.Count - 1);
                if (i == j) continue;

                var tempCard = deck.Cards[i];
                deck.Cards[i] = deck.Cards[j];
                deck.Cards[j] = tempCard;
            }

            return deck;
        }

        public static Deck Add(this Deck deck, int value, Suit suit)
        {
            deck.Cards.Add(new Card(value, suit));

            return deck;
        }

        public static Deck AddMultiple(this Deck deck, List<Card> setOfCards)
        {
            deck.Cards.AddRange(setOfCards);
        }
    }

}