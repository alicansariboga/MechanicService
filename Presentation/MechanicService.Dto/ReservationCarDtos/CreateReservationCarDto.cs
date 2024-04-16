namespace MechanicService.Dto.ReservationCarDtos
{
    public class CreateReservationCarDto
    {
        public int ModelID { get; set; }
        public int Year { get; set; }
        public string LicensePlate { get; set; }
        public int Km { get; set; }
    }
}
