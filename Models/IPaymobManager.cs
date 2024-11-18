namespace SampleApplication.Models
{
    public interface IPaymobManager
    {
        Task<string> GetPaymentKey(int amount, int quantity, string name, string description, string email, string currency = "EGP");
        Task<string> GetAuthenticationToken();
        Task<string> GetOrderId(string authToken, string amount, int quantity, string name, string description, string email, string currency = "EGP");
        Task<string> GetPayKey(string authToken, long orderId, decimal amount, string currency = "EGP");
    }
}
