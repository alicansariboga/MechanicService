﻿namespace MechanicService.WebUI.Models
{
    public class ReservationViewModel
    {
        public ResultReservationPersonDto personData { get; set; }
        public ResultReservationCarDto carData { get; set; }
        public ResultReservationServiceDto serviceData { get; set; }
    }
}
