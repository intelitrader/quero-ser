namespace MySolution.Models
{
    public enum StatusModel
    {
            Completed = 100,
            PaymentPending = 102,
            Cancelled = 135,
            NotCompleted = 190,
            ErroDesconhecido = 999
    }
    public static class StatusExtensions
{
    public static string ToFriendlyString(this StatusModel status)
    {
        switch(status)
        {
            case StatusModel.Completed:
                return "venda confirmada e com pagamento ok";
            case StatusModel.PaymentPending:
                return "venda confirmada, mas com pagamento pendente";
            case StatusModel.Cancelled:
                return "venda cancelada";
            case StatusModel.NotCompleted:
                return "venda não finalizada no canal de vendas";
            case StatusModel.ErroDesconhecido:
                return "erro não identificado";
            default:
                return "";
        }
    }
}
}