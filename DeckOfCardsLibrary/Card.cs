using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
        [Key]
        public int CardId { get; set; } = 0;
        public string Code { get; set; } = "";
        public string Value { get; set; } = "";

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Suit Suit { get; set; } = new();

        public Card()
        {
        }
        public Card(int value, Suit suit)
        {
            Value = value.ToString();
            Suit = suit;

            char suitInitial = Suit.ToString()[0];
            Code = $"{suitInitial}{Value}";
        }

        public override string ToString()
        {
            return $"{Suit}{Value}";
        }
    }
}

/*
        private Dictionary<int, string> ValueMap = new Dictionary<int, string>()
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
*/