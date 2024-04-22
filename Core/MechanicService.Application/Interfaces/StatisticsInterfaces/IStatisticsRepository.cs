namespace MechanicService.Application.Interfaces.StatisticsInterfaces
{
    public interface IStatisticsRepository
    {
        int GetAllReservationsCount();
        int GetCompletedReservationsCount();
        int GetPendingReservationsCount();
        int GetAllCustomersCount();
        int GetActiveLocationsCount();
        int GetReservationsTodayCount();
        int GetBrandCount();
        int GetBlogCount();
        int GetUnreadMessagesCount();
    }
}
