namespace MechanicService.WebUI.ViewComponents.LayoutViewComponents
{
    public class _LayoutFooterComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _LayoutFooterComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var footerViewModel = new FooterViewModel();

            var responseMessage = await client.GetAsync("https://localhost:7215/api/Services");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                footerViewModel.ServiceDatas = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
            }

            var responseMessage2 = await client.GetAsync("https://localhost:7215/api/Addresses");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage2.Content.ReadAsStringAsync();
                footerViewModel.AddressDatas = JsonConvert.DeserializeObject<List<ResultAddressDto>>(jsonData);
            }

            var responseMessage3 = await client.GetAsync("https://localhost:7215/api/SocialMedias");
            if (responseMessage3.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage3.Content.ReadAsStringAsync();
                footerViewModel.SocialMediaDatas = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsonData);
            }

            return View(footerViewModel);
        }
    }
}
