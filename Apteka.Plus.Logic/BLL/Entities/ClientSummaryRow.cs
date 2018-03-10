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

        public static Comparison<ClientSummaryRow> SumComparison = (p1, p2) => p1.Sum.CompareTo(p2.Sum);

        public static Comparison<ClientSummaryRow> ClientIDComparison = (p1, p2) => p1.ClientID.CompareTo(p2.ClientID);

        public static Comparison<ClientSummaryRow> DiscountComparison = (p1, p2) => p1.Discount.CompareTo(p2.Discount);

        public static Comparison<ClientSummaryRow> BuyCountComparison = (p1, p2) => p1.BuyCount.CompareTo(p2.BuyCount);

        public static Comparison<ClientSummaryRow> RowCountComparison = (p1, p2) => p1.RowCount.CompareTo(p2.RowCount);

        public static Comparison<ClientSummaryRow> DateOfRegistrationComparison = (p1, p2) => p1.DateOfRegistration.CompareTo(p2.DateOfRegistration);

        public static Comparison<ClientSummaryRow> DateofLastBuyComparison = (p1, p2) => p1.DateofLastBuy.CompareTo(p2.DateofLastBuy);
    }
}