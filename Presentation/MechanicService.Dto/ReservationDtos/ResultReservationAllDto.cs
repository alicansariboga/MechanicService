﻿namespace MechanicService.Dto.ReservationDtos
{
    public class ResultReservationAllDto
    {
        public int Id { get; set; }
        public int RezCarID { get; set; }
        public int RezPersonID { get; set; }
        public int RezServiceID { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsApproved { get; set; }
        public bool IsCanceled { get; set; }
        public string PersonName { get; set; }
        public string PersonSurname { get; set; }
        public string LicensePlate { get; set; }
        public DateTime ReservationDate { get; set; }
        public TimeSpan ReservationHour { get; set; }
    }
}
