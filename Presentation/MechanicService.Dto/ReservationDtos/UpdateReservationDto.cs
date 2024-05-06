namespace MechanicService.Dto.ReservationDtos
{
    public class UpdateReservationDto
    {
        public int Id { get; set; }
        public int RezCarID { get; set; }
        public int RezPersonID { get; set; }
        public int RezServiceID { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsApproved { get; set; }
        public bool IsCanceled { get; set; }
    }
}
