namespace MechanicService.WebUI.Models
{
    public class ReservationDetailViewModel
    {
        public ResultReservationPersonDto ReservationPerson { get; set; }
        public ResultReservationCarDto ReservationCar { get; set; }
        public ResultReservationServiceDto ReservationService { get; set; }
        public ResultReservationDetailDto ReservationCombined { get; set; }
    }
}
