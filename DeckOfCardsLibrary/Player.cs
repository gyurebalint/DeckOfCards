
namespace DeckOfCardsLibrary
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Card> Hand { get; set; }
        public int Money { get; set; }
        public Player(string name, int money = 0)
        {
            Hand = new List<Card>();
            Money = money;
            Name = name;
        }
    }
}
