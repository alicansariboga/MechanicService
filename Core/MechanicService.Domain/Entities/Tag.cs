namespace MechanicService.Domain.Entities
{
    public class Tag : BaseEntity
    {
        public string Title { get; set; }

        public int BlogID { get; set; }
        public Blog Blog { get; set; }
    }
}
