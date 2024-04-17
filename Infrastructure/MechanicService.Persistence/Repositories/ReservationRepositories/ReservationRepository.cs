namespace MechanicService.Persistence.Repositories.ReservationRepositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly MechanicServiceContext _context;

        public ReservationRepository(MechanicServiceContext context)
        {
            _context = context;
        }

        public int GetRepositoryCarId()
        {
            var lastInsertedCar = _context.ReservationCars
                                  .OrderByDescending(x => x.Id)
                                  .FirstOrDefault();

            if (lastInsertedCar != null)
            {
                return lastInsertedCar.Id;
            }

            return -1;
        }

        public int GetRepositoryPersonId()
        {
            var lastInsertedPerson = _context.ReservationPersons
                                  .OrderByDescending(x => x.Id)
                                  .FirstOrDefault();

            if (lastInsertedPerson != null)
            {
                return lastInsertedPerson.Id;
            }

            return -1;
        }

        public int GetRepositoryServiceId()
        {
            var lastInsertedService = _context.ReservationServices
                                  .OrderByDescending(x => x.Id)
                                  .FirstOrDefault();

            if (lastInsertedService != null)
            {
                return lastInsertedService.Id;
            }

            return -1;
        }
    }
}
