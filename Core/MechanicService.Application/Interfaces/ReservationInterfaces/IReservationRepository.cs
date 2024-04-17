namespace MechanicService.Application.Interfaces.ReservationInterfaces
{
    public interface IReservationRepository
    {
        int GetRepositoryPersonId();
        int GetRepositoryCarId();
        int GetRepositoryServiceId();
    }
}
