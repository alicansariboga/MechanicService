namespace MechanicService.Dto.StatisticsDtos
{
    public class ResultStatisticsDto
    {
        public int GetAllReservationsCount { get; set; }
        public int GetCompletedReservationsCount { get; set; }
        public int GetPendingReservationsCount { get; set; }
        public int GetAllCustomersCount { get; set; }
        public int GetActiveLocationsCount { get; set; }
        public int GetReservationsTodayCount { get; set; }
        public int GetBrandCount { get; set; }
        public int GetBlogCount { get; set; }
        public int GetUnreadMessagesCount { get; set; }
    }
}
