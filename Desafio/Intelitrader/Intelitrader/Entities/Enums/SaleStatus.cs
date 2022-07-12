namespace Intelitrader.Entities.Enums
{
    internal enum SaleStatus : int
    {
        ConfirmedAndPayd = 100,
        ConfirmedAndWaitingPayment = 102,
        Canceled = 135,
        NotFinished = 190,
        UnidentifiedError = 999
    }
}
