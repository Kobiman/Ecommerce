namespace EcommerceUI.Client.Services
{
    public interface ICartNotifier
    {
        void Subscribe(ICartObserver observer);
        void Unsubscribe(ICartObserver observer);
        void Notify(CartItem data);
    }
}
