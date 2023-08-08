namespace P03_Cards
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        static void Main(string[] args)
        {
            List<Card> cards = new List<Card>();

            string[] inputFaces = Console.ReadLine().Split(", ");

            foreach (var item in inputFaces)
            {
                string[] cardData = item.Split();
                string face = cardData[0];
                string suit = cardData[1];

                try
                {
                    Card card = new Card(face, suit);

                    cards.Add(card);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            Console.WriteLine(string.Join(" ", cards));


        }
    }


    public class Card
    {
        private const string Spade = "\u2660";
        private const string Heart = "\u2665";
        private const string Diamond = "\u2666";
        private const string Club = "\u2663";

        private string face;
        private string suit;

        private HashSet<string> allowedFaces = new HashSet<string>
                   { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
     
        private Dictionary<string, string> allowedSuits = new Dictionary<string, string>
        {
            { "S", Spade },
            { "H", Heart},
            { "D", Diamond },
            { "C", Club }
        };

        public Card(string face, string suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public string Face
        {
            get => this.face;
            set
            {
                if (!allowedFaces.Contains(value))
                {
                    throw new ArgumentException("Invalid card!");
                }

                this.face = value;
            }
        }

        public string Suit
        {
            get => this.suit;
            set
            {
                if (!allowedSuits.ContainsKey(value))
                {
                    throw new ArgumentException("Invalid card!");
                }

                this.suit = allowedSuits[value];
            }
        }

        public override string ToString()
        {
            return $"[{this.Face}{this.Suit}]";
        }

    }

}
