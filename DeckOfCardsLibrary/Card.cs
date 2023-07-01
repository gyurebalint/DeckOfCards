
namespace DeckOfCardsLibrary
{
    public enum Suit
    {
        Club,
        Spade,
        Heart,
        Diamond
    }
    public class Card
    {
        public int Id { get; set; }
        public Suit Suit { get; set; }
        public string Value { get; set; }
        private Dictionary<int, string> ValueMap;
        public Card(int value, Suit suit)
        {
            ValueMap = CreateValueMap();
            Value = ValueMap[value];
            Suit = suit;
        }

        private Dictionary<int, string> CreateValueMap()
        {
            return new Dictionary<int, string> ()
            {
                {1 , "1" },
                {2 , "2"},
                {3 , "3"},
                {4 , "4"},
                {5 , "5"},
                {6 , "6"},
                {7 , "7" },
                {8 , "8" },
                {9 , "9" },
                {10,"10" },
                {11,"Jack" },
                {12,"Queen" },
                {13,"King" },
            };
        }

        public override string ToString()
        {
            return $"Card Suit: {Suit}\nCard Value : {Value}\n\n";
        }

    }
}
