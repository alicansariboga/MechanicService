namespace MechanicService.Persistence.Repositories.ServiceRepositories
{
    public class ServiceDescriptionRepository : IServiceDescriptionRepository
    {
        private readonly MechanicServiceContext _context;

        public ServiceDescriptionRepository(MechanicServiceContext context)
        {
            _context = context;
        }

        public List<ServiceDescription> GetServiceDescriptionByServiceId(int id)
        {
            var values = _context.ServiceDescriptions.Where(x => x.ServiceID == id).ToList();
            return values;
        }
    }
}
