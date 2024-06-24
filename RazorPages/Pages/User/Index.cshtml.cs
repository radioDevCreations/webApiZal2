﻿using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;

namespace RazorPages.Pages.User
{
    using Domain.Entities;
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public IndexModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IList<User> User { get; set; } = new List<User>();

        public async Task OnGetAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7103/account");

            var token = HttpContext.Session.GetString("jwtToken"); ;

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadFromJsonAsync<IList<User>>();

                User = content;
            }
        }
    }
}
