﻿using MechanicService.Dto.BannerDtos;
using Newtonsoft.Json;

namespace MechanicService.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultBannerComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultBannerComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7215/api/Banners");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBannerDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
