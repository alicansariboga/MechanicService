namespace MechanicService.Dto.ReservationServiceDtos
{
    public class CreateReservationServiceDto
    {
        public string City { get; set; }
        public string Distinct { get; set; }
        public DateTime Date { get; set; }
        public DateTime Hour { get; set; }
        public string? Description { get; set; }
    }
}
