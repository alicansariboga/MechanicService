namespace MechanicService.WebUI.Models
{
    public class ReservationInformationViewModel
    {
        public ResultReservationPersonDto ReservationPerson { get; set; }
        public ResultReservationCarDto ReservationCar { get; set; }
        public ResultReservationServiceDto ReservationService { get; set; }
        public ResultReservationDto Reservation { get; set; }
    }
}
