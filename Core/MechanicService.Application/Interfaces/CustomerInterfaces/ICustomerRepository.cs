namespace MechanicService.Application.Interfaces.CustomerInterfaces
{
    public interface ICustomerRepository
    {
        List<CustomerViewModel> GetCustomersByReservationId();
        List<CustomerViewModel> GetCustomersAllReservationsByReservationId();
    }
}
