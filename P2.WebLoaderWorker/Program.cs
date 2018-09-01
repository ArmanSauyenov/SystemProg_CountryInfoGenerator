using Newtonsoft.Json;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace P2.WebLoaderWorker
{

    class WebServiceCountryLoader
    {
        private HttpClient _httpClient;
        private string _baseUri = "https://restcountries.eu/rest/v2/alpha/";

        public CountryDto GetCountry(CountryResearchRequest countryRequest)
        {
            string completeUrl = _baseUri + countryRequest.RequestedCountryCode;
            Uri uriBody = new Uri(completeUrl);
            string jsonResult = _httpClient.GetStringAsync(uriBody).Result;

            CountryDto dto = JsonConvert.DeserializeObject<CountryDto>(jsonResult);
            return dto;
        }

        public WebServiceCountryLoader()
        {
            _httpClient = new HttpClient();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            WebServiceCountryLoader countryLoader = new WebServiceCountryLoader();

            MessageBus<CountryResearchRequest> bus = new MessageBus<CountryResearchRequest>();

            bus.PullMessageFromQueue<CountryResearchRequest>();


            //CountryResearchRequest request = new CountryResearchRequest()
            //{
            //    RequestedCountryCode = "jpn"
            //};
           
            //WebServiceCountryLoader webService = new WebServiceCountryLoader();
            //CountryDto dto = webService.GetCountry(request);

            //Console.WriteLine(dto.ToString());

        }
    }
}
