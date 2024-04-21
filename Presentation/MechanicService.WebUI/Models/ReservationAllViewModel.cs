namespace MechanicService.WebUI.Models
{
    public class ReservationAllViewModel
    {
        public ResultReservationPersonDto ReservationPerson { get; set; }
        public ResultReservationCarDto ReservationCar { get; set; }
        public ResultReservationServiceDto ReservationService { get; set; }
        public List<ResultReservationDto> Reservations { get; set; }
    }
}
