namespace publish_subscriber;

// Multiple observers can subscribe to the same event, which makes this pattern ideal for a publish-subscribe scenario where many parts of the system need to respond to updates.

class Stock
{
	public string Symbol { get; set; }
	public decimal Price { get; set; }
	// Declare a delegate for price change notification
	public delegate void PriceChangedHandler(Stock stock);
	// Declare an event based on the delegate
	public event PriceChangedHandler PriceChanged;

	public void UpdatePrice(decimal newPrice)
	{
		if (Price != newPrice)
		{
			Price = newPrice;
			// Notify subscribers about the price change
			OnPriceChanged();
		}
	}

	protected virtual void OnPriceChanged()
	{
		if (PriceChanged != null)
		{
			PriceChanged(this); // Pass the stock object to the subscribers
		}
	}
}

class StockObserver
{
	private string _name;
	public StockObserver(string name)
	{
		_name = name;
	}

	public void Subscribe(Stock stock)
	{
		stock.PriceChanged += HandlePriceChange;
	}

	private void HandlePriceChange(Stock stock)
	{
		Console.WriteLine($"{_name} received notification: {stock.Symbol} new price is {stock.Price}");
	}
}

class Program
{
	static void Main(string[] args)
	{
		Stock myStock = new(){
			Symbol = "DAN",
			Price = 1500m
		}; 

		StockObserver observer1 = new("Observer 1"); 
		StockObserver observer2 = new("Observer 2");
		
		// Both observers subscribe to price changes
		observer1.Subscribe(myStock);
		observer2.Subscribe(myStock);

		// Update the stock price, which triggers the event
		myStock.UpdatePrice(1520m);
		myStock.UpdatePrice(1530m);
	}
}
