


Exo.Deck deck = new Exo.Deck();
deck.shuffle();
Exo.Deck[] players_deck = deck.split(4);

int i =1;
foreach (Exo.Deck val in players_deck)
{
    Console.WriteLine($"Player {i++} deck");
    val.display();
    Console.WriteLine("");
}

namespace Exo
{

    enum Colors
    {
        Coeur,Carreau,Pique,Trefle
    }

    enum V
    {
        Two = 2,    
        Three = 3,  
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,  
        Ace = 14        
    }

    struct Card
    {
        public Colors color;
        public V value;

    }

    struct Deck
    {
        Card[] cards = new Exo.Card[52];

        public Deck(Card[] deck){
            this.cards = deck;
        }

        public Deck()
        {

            int idx = 0;

             foreach (int color in Enum.GetValues(typeof(Exo.Colors)))
            {
                foreach (int value in Enum.GetValues(typeof(Exo.V)))
                {
                    cards[idx++] = new Exo.Card {color = (Exo.Colors) color,value = (Exo.V) value};
                }
            }
        }

        public Card[] getDeck(){
            return cards;
        }

        public void shuffle(){
            int rounds = Random.Shared.Next(20,50);
            for (int i = 0; i < rounds; i++)
            {
                int left = Random.Shared.Next(0,52);
                int right = Random.Shared.Next(0,52);
                (cards[right], cards[left]) = (cards[left], cards[right]);
            }
        }

        public Deck[] split(int n){
            Deck[] decks = new Deck[n];
            // try catch this 
            Card[][] chuncks = cards.Chunk(52/n).ToArray();
           
           for (int i = 0; i < n; i++)
           {
            decks[i] = new Deck(chuncks[i]);
           }

           return decks;
        }

        public void display(){
            foreach (Exo.Card card in cards)
            {
                Console.WriteLine($"{card.value}:{card.color}");
            }
        }
    }
}


