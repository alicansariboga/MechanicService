namespace MechanicService.Dto.ReservationCarDtos
{
    public class ResultReservationCarDto
    {
        public int Id { get; set; }
        public int ModelID { get; set; }
        public int Year { get; set; }
        public string LicensePlate { get; set; }
        public int Km { get; set; }
    }
}
