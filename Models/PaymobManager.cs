using SampleApplication.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace SampleApplication.Models
{
    public class PaymobManager : IPaymobManager
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly IRepository<Paymob> _paymobRepository;
        public PaymobManager(IConfiguration configuration, IRepository<Paymob> paymobRepository) 
        {
            _configuration = configuration;
            _httpClient = new HttpClient();
            _paymobRepository = paymobRepository;
        }
        public async Task<string> GetAuthenticationToken() 
        {
            string? api_key =  _configuration["Paymob:ApiKey"];
            var request = new HttpRequestMessage(HttpMethod.Post, "https://accept.paymob.com/api/auth/tokens");
            var content = new StringContent("{" + $"\"api_key\":\"{api_key}\"" + "}", null, "application/json");
            request.Content = content;
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetOrderId(string authToken, string amount, int quantity, string name, string description, string email, string currency = "EGP") 
        {
            string requestBody = "{" 
                + $"\"auth_token\":\"{authToken}\","
                + $"\"api_source\":\"INVOICE\","
                + $"\"amount_cents\":\"{amount}\","
                + $"\"currency\":\"{currency}\","
                + $"\"shipping_data\":" 
                + "{" 
                        + "\"first_name\":\"Test\","
                        + "\"last_name\":\"Account\","
                        + "\"phone_number\":\"01010101010\","
                        + $"\"email\":\"{email}\""
                + "},"
                + $"\"integrations\":[123,786],"
                + "\"items\": [" + "{"
                        + $"\"name\":\"{name}\","
                        + $"\"amount_cents\":\"{amount}\","
                        + $"\"quantity\":\"{quantity}\","
                        + $"\"description\":\"{description}\""
                + "}],"
                + $"\"delivery_needed\":\"false\""
                + "}";
            var request = new HttpRequestMessage(HttpMethod.Post, "https://accept.paymob.com/api/ecommerce/orders");
            var content = new StringContent(requestBody);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            request.Content = content;
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetPayKey(string authToken, long orderId, decimal amount, string currency = "EGP")
        {
            string? integration_id = _configuration["Paymob:Integration_Id"];
            string requestBody = "{" 
                + $"\"expiration\":3600,"
                + $"\"auth_token\":\"{authToken}\","
                + $"\"order_id\":{orderId},"
                + $"\"integration_id\":\"{integration_id}\","
                + $"\"amount_cents\":{amount},"
                + $"\"currency\":\"{currency}\","
                + $"\"billing_data\":" 
                    + "{" 
                            + $"\"first_name\":\"John\","
                            + $"\"last_name\":\"Doe\","
                            + $"\"email\":\"john.doe@example.com\","
                            + $"\"phone_number\":\"+20100000000\","
                            + $"\"apartment\":\"NA\","
                            + $"\"floor\":\"NA\","
                            + $"\"street\":\"123 Test St.\","
                            + $"\"building\":\"NA\","
                            + $"\"shipping_method\":\"NA\","
                            + $"\"postal_code\":\"12345\","
                            + $"\"city\":\"Cairo\","
                            + $"\"country\":\"EG\","
                            + $"\"state\":\"NA\""
                    + "}"
                + "}";
            var request = new HttpRequestMessage(HttpMethod.Post, "https://accept.paymob.com/api/acceptance/payment_keys");
            var content = new StringContent(requestBody, null, "application/json");
            request.Content = content;
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetPaymentKey(int amount, int quantity, string name, string description, string email , string currency = "EGP")
        {
            // 1. Get Authentication Token
            string getAuthanticationToken = await GetAuthenticationToken();
            JsonDocument authDoc = JsonDocument.Parse(getAuthanticationToken);
            JsonElement root = authDoc.RootElement;
            string? auth_token = root.GetProperty("token").GetString();
            //2. Get Order
            string getOrderId = await GetOrderId(auth_token, (amount*100).ToString(), quantity, name, description, email, currency);
            JsonDocument orderDoc = JsonDocument.Parse(getOrderId);
            JsonElement orderRoot = orderDoc.RootElement;
            string? url = orderRoot.GetProperty("url").GetString();
            Paymob paymob = new Paymob() { Order=getOrderId };
            _paymobRepository.Create(paymob);
            _paymobRepository.Save();

            return url;
        }
    }
}
