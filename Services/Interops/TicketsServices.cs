using RestSharp;
using RestSharp.Serializers.Utf8Json;
using Services.Interops.Request;
using Utf8Json;

namespace Services.Interops
{
    public class TicketsServices
    {
        private readonly RestClient _apiClient;
        
        public TicketsServices()
        {
            var baseURL = "http://localhost:5292/api/";

            _apiClient = new RestClient(baseURL);
        }

        public async Task<CreateTickets> GetCreateTicket()
        {
            var request = new RestRequest("Registrar",Method.Get);
     
            string responseContent = null;
            try
            {
                var response = await _apiClient.ExecuteAsync(request,CancellationToken.None);
                responseContent = response.Content;
                if (response.IsSuccessful)
                {
                    return JsonSerializer.Deserialize<CreateTickets>(responseContent);
                }
                return new CreateTickets();
            }
            catch (JsonParsingException e)
            {
                return new CreateTickets();
            }
            catch (Exception e)
            {
                return new CreateTickets();
            }
        }
    }
}
