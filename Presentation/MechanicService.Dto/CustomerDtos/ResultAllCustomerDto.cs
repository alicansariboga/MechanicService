namespace MechanicService.Dto.CustomerDtos
{
    public class ResultAllCustomerDto
    {
        public int Id { get; set; }
        public int RezPersonID { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsApproved { get; set; }
        public bool IsCanceled { get; set; }
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdentityNumber { get; set; }
        public string Phone { get; set; }
        public string PhoneOpt { get; set; }
        public string Email { get; set; }
    }
}
