namespace MechanicService.Domain.Entities
{
    public class Tag : BaseEntity
    {
        public string Title { get; set; }

        [ForeignKey("BlogID")]
        public int BlogID { get; set; }
        public Blog Blog { get; set; }
    }
}
