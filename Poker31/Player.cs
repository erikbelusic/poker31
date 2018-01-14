namespace Poker31
{ 
    public class Player
    {
        private readonly string _name;
        private readonly Hand _hand = new Hand();

        public Player(string name)
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }

        public void addCardToHand(Card card)
        {
            _hand.AddCard(card);
        }

        public Hand GetHand()
        {
            return _hand;
        }
    }
}