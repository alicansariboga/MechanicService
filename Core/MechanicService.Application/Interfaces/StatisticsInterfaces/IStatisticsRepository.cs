namespace MechanicService.Application.Interfaces.StatisticsInterfaces
{
    public interface IStatisticsRepository
    {
        int GetAllReservationsCount();
        int GetCompletedReservationsCount();
        int GetPendingReservationsCount();
        int GetAllCustomersCount();
        int GetActiveLocationsCount();
        int GetActiveLocationsCityCount();
        int GetActiveLocationsDistrictCount();
        int GetReservationsTodayCount();
        int GetBrandCount();
        int GetModelCount();
        int GetBlogCount();
        int GetUnreadMessagesCount();
    }
}
