namespace EcommerceUI.Client.Services
{
    public sealed record CartItem(
        string ProductId,
        string Name,
        string Image, 
        int Quantity,
        double UnitPrice,
        double TotalPrice,
        string Brand,
        string Description);
}
