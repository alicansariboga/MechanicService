namespace MechanicService.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("BlogID")]
        public int BlogID { get; set; }
        public Blog Blog { get; set; }
    }
}
