using CsharpPoker;
using System.Collections.Concurrent;

public static class EvalExtensions
{
	public static IEnumerable<KeyValuePair<CardValue, int>> ToKindAndQuantities(this IEnumerable<Card> cards)
	{
		ConcurrentDictionary<CardValue, int> dict = new();
		foreach (var card in cards)
		{
			dict.AddOrUpdate(card.Value, 1, (cardValue, quantity) => ++quantity);
		}
		return dict;
	}

	// This is generic where you can use it on any type of value
	public static IEnumerable<TResult> SelectConsecutive<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TSource, TResult> selector)
	{
		int index = -1;
		foreach (TSource element in source.Take(source.Count() - 1))
		{
			checked { index++; }
			yield return selector(element, source.ElementAt(index + 1));
		}
	}

	public static HandRank Score(this Hand hand) => FiveCardPokerScorer.GetHandRank(hand.Cards);
}