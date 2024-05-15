namespace MechanicService.Dto.ReservationServiceDtos
{
    public class ResultReservationServiceDto
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Distinct { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Hour { get; set; }
        public string? Description { get; set; }
        public string ServiceName { get; set; }
    }
}
