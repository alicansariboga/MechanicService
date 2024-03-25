namespace MechanicService.Domain.Entities
{
    public class Campaign : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string DiscountTitle1 { get; set; }
        public double Discount1 { get; set; }
        public string? DiscountTitle2 { get; set; }
        public double? Discount2 { get; set; }
        public string? DiscountTitle3 { get; set; }
        public double? Discount3 { get; set; }
    }
}