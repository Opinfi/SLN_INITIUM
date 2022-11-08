using Newtonsoft.Json;
using RestSharp;
using Services.Interops.Request;
using Utf8Json;
using JsonSerializer = Utf8Json.JsonSerializer;

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
            var request = new RestRequest("Tickets/Registrar",Method.Get);
     
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
        public async Task<string> CreateTicket(CreateTickets createTickets)
        {
            var request = new RestRequest("Tickets", Method.Post);
            request.AddHeader("Content-Type", "application/json; charset=utf8");
 
            var re = JsonConvert.SerializeObject(createTickets);
    
            request.AddParameter("application/json", re, ParameterType.RequestBody);
            try
            {
                var r = await _apiClient.ExecuteAsync(request, Method.Post);
                var responseContent = r.Content;
                if (!r.IsSuccessful)
                {
                   return null; 
                }
                return responseContent;
            }
            catch (JsonParsingException e)
            {
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
