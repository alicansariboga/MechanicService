using Humanizer;
using MechanicService.Application.ViewModel;
using MechanicService.Domain.Entities;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Collections.Concurrent;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MechanicService.Persistence.Repositories.CustomerRepositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MechanicServiceContext _context;

        public CustomerRepository(MechanicServiceContext context)
        {
            _context = context;
        }
        public List<CustomerViewModel> GetCustomersByReservationPersonId()
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
