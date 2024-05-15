namespace MechanicService.WebUI.Models
{
    public class ReservationCreateViewModel
    {
        public CreateReservationPersonDto ReservationPerson { get; set; }
        public CreateReservationCarDto ReservationCar { get; set; }
        public CreateReservationServiceDto ReservationService { get; set; }
        public List<ResultReservationServiceDto> ResultReservationServiceDtos { get; set; }
        public List<ResultServiceDto> Services { get; set; }
    }
}
