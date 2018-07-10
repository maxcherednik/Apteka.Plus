namespace Apteka.Plus.CashRegister
{
    public interface IGood
    {
        string Name { get; set; }

        float Amount { get; set; }

        double Price { get; set; }

        double PriceWithDiscount { get; set; }

        double Discount { get; set; }
    }
}
