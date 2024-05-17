namespace MechanicService.Application.Interfaces.ServiceInterfaces
{
    public interface IServiceDescriptionRepository
    {
        List<ServiceDescription> GetServiceDescriptionByServiceId(int id);
    }
}
