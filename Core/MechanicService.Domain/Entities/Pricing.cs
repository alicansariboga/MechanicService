namespace MechanicService.Domain.Entities
{
    public class Pricing : BaseEntity
    {
        public string ProcessName { get; set; }
        public double ProcessCost { get; set; }
        public string ProcessCategory { get; set; }
    }
}
