namespace MechanicService.Domain.Entities
{
    public class Address : BaseEntity
    {
        public string Description { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Phone { get; set; }
        public string PhoneOpt { get; set; }
        public string LongAddress { get; set; }
        public string Email { get; set; }
    }
}
