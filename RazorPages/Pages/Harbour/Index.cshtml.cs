using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Net.Http.Headers;

namespace RazorPages.Pages.Harbour
{
    using Domain.Entities;
    public class IndexModel : PageModel
    {       
        private readonly IHttpClientFactory _httpClientFactory;

        public IndexModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public IList<Harbour> Harbour { get;set; } = new List<Harbour>();

        public async Task OnGetAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7103/harbours");

            var token = HttpContext.Session.GetString("jwtToken"); ;

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode) 
            {
                var content = await response.Content.ReadFromJsonAsync<IList<Harbour>>();

                Harbour = content;
            }
        }
    }
}
