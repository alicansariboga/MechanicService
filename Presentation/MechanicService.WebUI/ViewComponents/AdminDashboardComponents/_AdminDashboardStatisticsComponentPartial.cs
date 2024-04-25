namespace MechanicService.WebUI.ViewComponents.AdminDashboardComponents
{
    public class _AdminDashboardStatisticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminDashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            #region Statistic-allReservations
            var responseMessage1 = await client.GetAsync("https://localhost:7215/api/Statistics/GetAllReservationsCount/");
            if (responseMessage1.IsSuccessStatusCode)
            {
                var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
                var values1 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData1);
                ViewBag.allReservations = values1.GetAllReservationsCount;
            }
            #endregion

            #region Statistic-completedReservations
            var responseMessage2 = await client.GetAsync("https://localhost:7215/api/Statistics/GetCompletedReservationsCount/");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData1 = await responseMessage2.Content.ReadAsStringAsync();
                var values1 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData1);
                ViewBag.completedReservations = values1.GetCompletedReservationsCount;
            }
            #endregion

            #region Statistic-pendingReservations
            var responseMessage3 = await client.GetAsync("https://localhost:7215/api/Statistics/GetPendingReservationsCount/");
            if (responseMessage3.IsSuccessStatusCode)
            {
                var jsonData1 = await responseMessage3.Content.ReadAsStringAsync();
                var values1 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData1);
                ViewBag.pendingReservations = values1.GetPendingReservationsCount;
            }
            #endregion

            #region Statistic-allCustomers
            var responseMessage4 = await client.GetAsync("https://localhost:7215/api/Statistics/GetAllCustomersCount/");
            if (responseMessage4.IsSuccessStatusCode)
            {
                var jsonData1 = await responseMessage4.Content.ReadAsStringAsync();
                var values1 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData1);
                ViewBag.allCustomers = values1.GetAllCustomersCount;
            }
            #endregion

            #region Statistic-activeLocations
            var responseMessage5 = await client.GetAsync("https://localhost:7215/api/Statistics/GetActiveLocationsCount");
            if (responseMessage5.IsSuccessStatusCode)
            {
                var jsonData1 = await responseMessage5.Content.ReadAsStringAsync();
                var values1 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData1);
                ViewBag.activeLocations = values1.GetActiveLocationsCount;
            }
            #endregion

            #region Statistic-reservationsToday
            var responseMessage6 = await client.GetAsync("https://localhost:7215/api/Statistics/GetReservationsTodayCount/");
            if (responseMessage6.IsSuccessStatusCode)
            {
                var jsonData1 = await responseMessage6.Content.ReadAsStringAsync();
                var values1 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData1);
                ViewBag.reservationsToday = values1.GetReservationsTodayCount;
            }
            #endregion

            #region Statistic-brands
            var responseMessage7 = await client.GetAsync("https://localhost:7215/api/Statistics/GetBrandCount/");
            if (responseMessage7.IsSuccessStatusCode)
            {
                var jsonData1 = await responseMessage7.Content.ReadAsStringAsync();
                var values1 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData1);
                ViewBag.brands = values1.GetBrandCount;
            }
            #endregion

            #region Statistic-blogs
            var responseMessage8 = await client.GetAsync("https://localhost:7215/api/Statistics/GetBlogCount/");
            if (responseMessage8.IsSuccessStatusCode)
            {
                var jsonData1 = await responseMessage8.Content.ReadAsStringAsync();
                var values1 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData1);
                ViewBag.blogs = values1.GetBlogCount;
            }
            #endregion

            #region Statistic-unreadMessages
            var responseMessage9 = await client.GetAsync("https://localhost:7215/api/Statistics/GetUnreadMessagesCount/");
            if (responseMessage9.IsSuccessStatusCode)
            {
                var jsonData1 = await responseMessage9.Content.ReadAsStringAsync();
                var values1 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData1);
                ViewBag.unreadMessages = values1.GetUnreadMessagesCount;
            }
            #endregion

            return View();
        }
    }
}
