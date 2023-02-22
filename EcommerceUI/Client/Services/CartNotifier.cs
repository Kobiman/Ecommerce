namespace EcommerceUI.Client.Services
{
    public class CartNotifier : ICartNotifier
    {
        private static IList<ICartObserver> observers;
        public CartNotifier()
        {
            observers = new List<ICartObserver>();

        }

        public void Subscribe(ICartObserver observer)
        {
            observers.Add(observer);
        }

        public void Unsubscribe(ICartObserver observer)
        {
            observers.Remove(observer);
        }

        public void Notify(CartItem data)
        {
            foreach (ICartObserver observer in observers)
            {
                Task.Run(() => observer.Update(data));
            }
        }
    }
}
