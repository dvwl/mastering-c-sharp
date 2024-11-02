namespace CsharpPoker;

public class Hand
{
	private readonly List<Card> cards = [];

	public IEnumerable<Card> Cards => cards;

	public void Draw(Card card) => cards.Add(card);
}
