using System;
namespace Apteka.Plus.Logic.BLL.Entities
{
    public class ClientSummaryRow
    {
        public string ClientID { get; set; }
        public double Sum { get; set; }
        public double Discount { get; set; }
        public int BuyCount { get; set; }
        public int RowCount { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public DateTime DateofLastBuy { get; set; }
        public float? DiscountSize { get; set; }

        public static Comparison<ClientSummaryRow> SumComparison = delegate(ClientSummaryRow p1, ClientSummaryRow p2)
        {
            return p1.Sum.CompareTo(p2.Sum);
        };

        public static Comparison<ClientSummaryRow> ClientIDComparison = delegate(ClientSummaryRow p1, ClientSummaryRow p2)
        {
            return p1.ClientID.CompareTo(p2.ClientID);
        };

        public static Comparison<ClientSummaryRow> DiscountComparison = delegate(ClientSummaryRow p1, ClientSummaryRow p2)
        {
            return p1.Discount.CompareTo(p2.Discount);
        };
        public static Comparison<ClientSummaryRow> BuyCountComparison = delegate(ClientSummaryRow p1, ClientSummaryRow p2)
        {
            return p1.BuyCount.CompareTo(p2.BuyCount);
        };

        public static Comparison<ClientSummaryRow> RowCountComparison = delegate(ClientSummaryRow p1, ClientSummaryRow p2)
        {
            return p1.RowCount.CompareTo(p2.RowCount);
        };

        public static Comparison<ClientSummaryRow> DateOfRegistrationComparison = delegate(ClientSummaryRow p1, ClientSummaryRow p2)
        {
            return p1.DateOfRegistration.CompareTo(p2.DateOfRegistration);
        };
        public static Comparison<ClientSummaryRow> DateofLastBuyComparison = delegate(ClientSummaryRow p1, ClientSummaryRow p2)
        {
            return p1.DateofLastBuy.CompareTo(p2.DateofLastBuy);
        };
        
    }
}