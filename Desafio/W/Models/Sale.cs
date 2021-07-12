using System;

namespace W.Models
{
    public class Sale
    {

        public Sale(string source, int line)
        {
            var split = source.Split(";");
            Line = line;
            ProductCode = Convert.ToInt32(split[0]);
            Quantity = Convert.ToInt32(split[1]);
            Status = (SaleStatus)Convert.ToInt32(split[2]);
            Channel = (SaleChannel)Convert.ToInt32(split[3]);
        }

        public int Line { get; init; }
        public int ProductCode { get; init; }
        public int Quantity { get; init; }
        public SaleStatus Status { get; init; }
        public SaleChannel Channel { get; init; }

    }

    public enum SaleStatus
    {
        ConfirmedAndPaid = 100,
        ConfirmedAndAwaitingPayment = 102,
        Canceled = 135,
        Unfinished = 190,
        Error = 999
    }

    public enum SaleChannel
    {
        Representative = 1,
        Website = 2,
        AppAndroid = 3,
        AppIOS = 4
    }
}
