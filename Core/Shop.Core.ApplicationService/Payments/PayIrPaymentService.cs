using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Shop.Core.Domain.Payments.Entities;
using System.Collections.Generic;
using System.Net.Http;


namespace Shop.Core.ApplicationService.Payments
{
    public class PayIrPaymentService : PaymentService
    {
        private readonly IConfiguration _configuration;

        public PayIrPaymentService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public RequestPaymentResult RequestPayment(string amount, string mobile, string factorNumber, string description)
        {
            HttpClient client = new HttpClient();
            Dictionary<string, string> post_values = new Dictionary<string, string>();
            post_values.Add("api", _configuration["PayIr:ApiKey"]);
            post_values.Add("amount", amount.ToString());
            post_values.Add("redirect", _configuration["PayIr:RedirectUrl"]);
            post_values.Add("mobile", mobile);
            post_values.Add("factorNumber", factorNumber);
            post_values.Add("description", description);
            var content = new FormUrlEncodedContent(post_values);
            var response = client.PostAsync(_configuration["PayIr:SendRequestUrl"], content).Result;

            var responseString = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<RequestPaymentResult>(responseString);
        }

        public VerifyPayemtnResult VerifyPayment(string token)
        {
            HttpClient client = new HttpClient();
            Dictionary<string, string> post_values = new Dictionary<string, string>();
            post_values.Add("api", _configuration["PayIr:ApiKey"]);
            post_values.Add("token", token);
            var content = new FormUrlEncodedContent(post_values);
            var response = client.PostAsync(_configuration["PayIr:VerifyUrl"], content).Result;
            var responseString = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<VerifyPayemtnResult>(responseString);
        }
    }
}
