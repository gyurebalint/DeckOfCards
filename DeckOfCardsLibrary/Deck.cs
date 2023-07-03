using System.ComponentModel.DataAnnotations;

namespace DeckOfCardsLibrary
{
    public interface IDeckOfCards
    {
        public List<Card> DrawRandom(int numberOfTimes);
        public List<Card> DrawFromTop(int numberOfTimes);
    }

    public class Deck : IDeckOfCards
    {
        //At first we create a concrete poker deck then we generalize
        Random Rand = new Random();

        [Key]
        public int DeckId { get; set; }
        public int Capacity { get; private set;}
        public int Count { get; set; }

        private int numberOfCardsPerSuit;
        public List<Card> Cards { get; set; } = new();
        public Deck()
        {
        }
        public Deck(int size = 52)
        {
            Cards = new List<Card>();
            var suits = Enum.GetValues<Suit>();
            numberOfCardsPerSuit = size / 4;

            foreach (Suit suit in suits)
            {
                for (int i = 1; i <= numberOfCardsPerSuit; i++)
                {
                    Cards.Add(new Card(i, suit));
                    Capacity++;
                }
            }
            Count = Capacity;
        }

        public List<Card> DrawRandom(int numberOfTimes)
        {
            List<Card> drawnCards = new();
            for (int i = 0; i < numberOfTimes; i++)
            {
                var index = Rand.Next(1, Cards.Count);
                var drawnCard = Cards[index];
                drawnCards.Add(drawnCard);
                Count--;

                Cards.RemoveAt(index);
            }

            return drawnCards;
        }

        public List<Card> DrawFromTop(int numberOfTimes)
        {
            List<Card> drawnCards = new();

            for (int i = 0; i < numberOfTimes; i++)
            {
                var topIndex = Cards.Count - 1;
                var topCard = Cards[topIndex];
                drawnCards.Add(topCard);
                Count--;

                Cards.RemoveAt(topIndex);
            }

            return drawnCards;
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
            deck.Count++;

            return deck;
        }

        public static Deck AddMultiple(this Deck deck, List<Card> setOfCards)
        {
            deck.Cards.AddRange(setOfCards);
            deck.Count += setOfCards.Count;

            return deck;
        }
    }
}