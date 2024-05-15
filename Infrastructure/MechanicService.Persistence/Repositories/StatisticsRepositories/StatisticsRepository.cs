namespace MechanicService.Persistence.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly MechanicServiceContext _context;

        public StatisticsRepository(MechanicServiceContext context)
        {
            _context = context;
        }

        public int GetActiveLocationsCityCount()
        {
            // SELECT * FROM LocationCities
            // LEFT JOIN LocationDistricts
            // On LocationCities.Id = LocationDistricts.CityID WHERE LocationDistricts.IsActive = 1

            var list = new List<int>();
            var list2 = new List<int>();
            list = _context.LocationDistricts.Where(x => x.IsActive == true).Select(y => y.CityID).ToList();
            foreach (var cityId in list)
            {
                int value = _context.LocationCities.Where(x => x.Id == cityId).Select(y => y.Id).FirstOrDefault();
                list2.Add(value);
            }
            var results = list2.Distinct().Count();
            return results;
        }

        public int GetActiveLocationsDistrictCount()
        {
            // SELECT * FROM LocationDistricts WHERE IsActive = 'true'
            var values = _context.LocationDistricts.Where(x => x.IsActive == true).Count();
            return values;
        }

        public int GetActiveLocationsCount()
        {

            // SELECT * FROM BranchOffices 
            var values = _context.BranchOffices.Count();
            return values;

        }

        public int GetAllCustomersCount()
        {
            // SELECT COUNT(DISTINCT(ReservationPersons.IdentityNumber)) FROM ReservationPersons

            var values = _context.ReservationPersons.Select(x => x.IdentityNumber).Distinct().Count();
            return values;
        }

        public int GetAllReservationsCount()
        {
            var values = _context.Reservations.Count();
            return values;
        }

        public int GetBlogCount()
        {
            var values = _context.Blogs.Count();
            return values;
        }

        public int GetBrandCount()
        {
            var values = _context.CarBrands.Count();
            return values;
        }

        public int GetModelCount()
        {
            // SELECT * FROM CarModels 
            var values = _context.CarModels.Count();
            return values;
        }

        public int GetCompletedReservationsCount()
        {
            var values = _context.Reservations.Where(x => x.IsApproved == true && x.IsCanceled == false).Count();
            return values;
        }

        public int GetPendingReservationsCount()
        {
            var values = _context.Reservations.Where(x => x.IsApproved == false && x.IsCanceled == false).Count();
            return values;
        }

        public int GetReservationsTodayCount()
        {
            // SELECT COUNT(*) FROM ReservationServices WHERE ReservationServices.Date = '2024-04-22'
            var values = _context.ReservationServices.Where(x => x.Date == DateTime.Now.Date).Count();
            return values;
        }

        public int GetUnreadMessagesCount()
        {
            var values = _context.Contacts.Where(x => x.Isread == false).Count();
            return values;
        }
    }
}
