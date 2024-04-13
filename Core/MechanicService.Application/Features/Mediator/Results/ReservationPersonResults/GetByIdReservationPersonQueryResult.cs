namespace MechanicService.Application.Features.Mediator.Results.ReservationPersonResults
{
    public class GetByIdReservationPersonQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdentityNumber { get; set; }
        public string Phone { get; set; }
        public string PhoneOpt { get; set; }
        public string Email { get; set; }
    }
}
