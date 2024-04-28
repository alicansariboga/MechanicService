namespace MechanicService.Persistence.Repositories.CustomerRepositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MechanicServiceContext _context;

        public CustomerRepository(MechanicServiceContext context)
        {
            _context = context;
        }

        public List<CustomerViewModel> GetCustomersAllReservationsByReservationId()
        {
            var results = _context.Reservations
                        .GroupJoin(_context.ReservationPersons,
                         reservation => reservation.RezPersonID,
                         person => person.Id,
                         (reservation, persons) => new { Reservation = reservation, Persons = persons })
                         .SelectMany(
                         x => x.Persons.DefaultIfEmpty(),
                         (reservation, person) => new { Reservation = reservation.Reservation, Person = person }
                         ).ToList();
            var customerViewModels = results.Select(x => new CustomerViewModel
            {
                Id = x.Reservation.Id,
                RezPersonID = x.Reservation.RezPersonID,
                CreateDate = x.Reservation.CreateDate,
                IsApproved = x.Reservation.IsApproved,
                IsCanceled = x.Reservation.IsCanceled,
                PersonId = x.Person.Id,
                Name = x.Person.Name,
                Surname = x.Person.Surname,
                IdentityNumber = x.Person.IdentityNumber,
                Phone = x.Person.Phone,
                PhoneOpt = x.Person.PhoneOpt,
                Email = x.Person.Email
            }).ToList();
            return customerViewModels;
        }

        public List<CustomerViewModel> GetCustomersByReservationId()
        {
            //ADO/NET DB Conn
            List<CustomerViewModel> values = new List<CustomerViewModel>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT Reservations.*, ReservationPersons.PersonId, ReservationPersons.Name, ReservationPersons.Surname, ReservationPersons.IdentityNumber, ReservationPersons.Phone, ReservationPersons.PhoneOpt, ReservationPersons.Email FROM Reservations LEFT JOIN (SELECT Id AS PersonId, Name, Surname, IdentityNumber, Phone, PhoneOpt, Email, ROW_NUMBER() OVER(PARTITION BY IdentityNumber ORDER BY Id) AS RowNum FROM ReservationPersons) AS ReservationPersons ON ReservationPersons.PersonId = Reservations.RezPersonID WHERE ReservationPersons.RowNum = 1;;";
                command.CommandType = System.Data.CommandType.Text;
                _context.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CustomerViewModel carPricingViewModel = new CustomerViewModel()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            RezPersonID = Convert.ToInt32(reader["RezPersonID"]),
                            CreateDate = Convert.ToDateTime(reader["CreateDate"]),
                            IsApproved = Convert.ToBoolean(reader["IsApproved"]),
                            IsCanceled = Convert.ToBoolean(reader["IsCanceled"]),
                            PersonId = Convert.ToInt32(reader["PersonId"]),
                            Name = reader["Name"].ToString(),
                            Surname = reader["Surname"].ToString(),
                            IdentityNumber = reader["IdentityNumber"].ToString(),
                            Phone = reader["Phone"].ToString(),
                            PhoneOpt = reader["PhoneOpt"].ToString(),
                            Email = reader["Email"].ToString(),
                        };
                        values.Add(carPricingViewModel);
                    }
                }
            }
            _context.Database.CloseConnection();
            return values;
        }
    }
}
