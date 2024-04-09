﻿using MechanicService.Dto.TeamDtos;
using Newtonsoft.Json;

namespace MechanicService.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultTeamComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultTeamComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7215/api/Teams");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTeamDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
