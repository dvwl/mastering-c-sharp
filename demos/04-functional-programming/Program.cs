namespace CsharpPoker;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Poker Hand Evaluator!");

        // Generate or input a sample hand
        var hand = GenerateSampleHand(); // You could replace this with user input for custom hands

        Console.WriteLine("Your hand:");
        DisplayHand(hand);

        // Evaluate the hand rank
        HandRank rank = FiveCardPokerScorer.GetHandRank(hand);

        // Display the hand rank
        Console.WriteLine($"\nYour hand ranks as: {rank}");
    }

    // Generate a sample hand (replace with custom input if desired)
    private static List<Card> GenerateSampleHand()
    {
        // Example hand: (Adjust as necessary for testing or demonstration purposes)
        return
        [
            new Card(CardValue.Ten, CardSuit.Hearts),
            new Card(CardValue.Jack, CardSuit.Hearts),
            new Card(CardValue.Queen, CardSuit.Hearts),
            new Card(CardValue.King, CardSuit.Hearts),
            new Card(CardValue.Ace, CardSuit.Hearts)
        ];
    }

    // Display each card in the hand
    private static void DisplayHand(IEnumerable<Card> hand)
    {
        foreach (var card in hand)
        {
            Console.WriteLine($"{card.Value} of {card.Suit}");
        }
    }
}
