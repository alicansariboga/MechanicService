namespace MechanicService.Domain.Entities
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("CategoryID")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
